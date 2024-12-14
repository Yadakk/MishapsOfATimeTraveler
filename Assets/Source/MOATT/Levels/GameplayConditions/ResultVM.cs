﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.GameplayConditions
{
    public class ResultVM : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;

        private LevelProgress levelProgress;
        private LevelLostInvoker levelLostInvoker;

        private bool resultFlag;

        [Inject]
        public void Construct(LevelProgress levelProgress, LevelLostInvoker levelLostInvoker)
        {
            this.levelProgress = levelProgress;
            this.levelLostInvoker = levelLostInvoker;
        }

        private void Awake()
        {
            levelProgress.OnWon += WonHandler;
            levelLostInvoker.OnLost += LostHandler;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            levelProgress.OnWon -= WonHandler;
            levelLostInvoker.OnLost -= LostHandler;
        }

        private void WonHandler()
        {
            if (resultFlag) return;
            gameObject.SetActive(true);
            label.text = "You won";
            resultFlag = true;
        }

        private void LostHandler()
        {
            if (resultFlag) return;
            gameObject.SetActive(true);
            label.text = "You lost";
            resultFlag = true;
        }
    }
}
