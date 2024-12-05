using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MOATT.Tooltips
{
    public class Tooltip : MonoBehaviour
    {
        public Vector2 offset;

        private TextMeshProUGUI tmpu;
        private RectTransform rt;

        private void Awake()
        {
            tmpu = GetComponentInChildren<TextMeshProUGUI>();
            rt = transform as RectTransform;
        }

        private void Start()
        {
            SetActive(false);
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

        public void MoveToCursor() => rt.transform.position = Input.mousePosition + (Vector3)offset;

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
    }
}
