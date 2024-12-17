using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace MOATT.Tooltips
{
    public class Tooltip : MonoBehaviour
    {
        public Vector2 offset;

        private TextMeshProUGUI tmpu;
        private RectTransform rt;
        private RectTransform canvasRT;

        public event Action OnShown;

        private void Awake()
        {
            tmpu = GetComponentInChildren<TextMeshProUGUI>();
            rt = transform as RectTransform;
            canvasRT = GetComponentInParent<Canvas>().transform as RectTransform;
        }

        private void Start()
        {
            SetActive(false);
        }

        private void OnEnable()
        {
            OnShown?.Invoke();
        }

        private void Update()
        {
            MoveToCursor();
        }

        public void SetText(string text)
        {
            tmpu.text = text;
            rt.sizeDelta = new(tmpu.preferredWidth, tmpu.preferredHeight);
        }

        public void SetActive(bool value) => gameObject.SetActive(value);

        public void MoveToCursor()
        {
            transform.position = Input.mousePosition + (Vector3)offset;
            KeepFullyOnScreen();
        }

        public void DisplayAtCursor(string text)
        {
            SetText(text);
            SetActive(true);
            MoveToCursor();
        }

        public void Hide()
        {
            SetActive(false);
        }

        private void KeepFullyOnScreen()
        {
            Vector3 pos = rt.localPosition;

            Vector3 minPosition = canvasRT.rect.min - rt.rect.min * rt.localScale;
            Vector3 maxPosition = canvasRT.rect.max - rt.rect.max * rt.localScale;

            pos.x = Mathf.Clamp(rt.localPosition.x, minPosition.x, maxPosition.x);
            pos.y = Mathf.Clamp(rt.localPosition.y, minPosition.y, maxPosition.y);

            rt.localPosition = pos;
        }
    }
}
