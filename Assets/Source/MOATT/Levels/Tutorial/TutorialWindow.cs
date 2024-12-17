using MOATT.Levels.Tutorial.States;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MOATT.Levels.Tutorial
{
    public class TutorialWindow : MonoBehaviour
    {
        private RectTransform rt;
        private float displayedY;
        private float collapsedY;

        private TutorialState state;

        [field: SerializeField] public TextMeshProUGUI ContentTmpu { get; private set; }
        [field: SerializeField] public Button NextButton { get; private set; }

        public bool IsCollapsed { get; private set; }

        private void Awake()
        {
            rt = transform as RectTransform;
            displayedY = rt.anchoredPosition.y;
            collapsedY = -rt.sizeDelta.y;
        }

        private void Update()
        {
            state?.Update();
        }

        public void SetCollapsed(bool value)
        {
            rt.anchoredPosition = new(rt.anchoredPosition.x, value ? collapsedY : displayedY);
            IsCollapsed = value;
        }

        public void ToggleCollapsed() => SetCollapsed(!IsCollapsed);

        public void SetState(TutorialState newState)
        {
            state?.Dispose();
            state = newState;
            state?.Start();
        }

        public void SetActiveNextButton(bool value) => NextButton.gameObject.SetActive(value);
        public void SetTextContent(string text) => ContentTmpu.text = text;

        public void SetNextButtonEvent(Action action)
        {
            NextButton.onClick.RemoveAllListeners();
            NextButton.onClick.AddListener(new(action));
        }
    }
}
