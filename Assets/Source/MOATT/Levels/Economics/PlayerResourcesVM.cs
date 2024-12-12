using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

namespace MOATT.Levels.Economics
{
    public class PlayerResourcesVM : MonoBehaviour
    {
        public TextMeshProUGUI nutsAndBoltsTmpu;
        public TextMeshProUGUI scientistsTmpu;

        private PlayerResources playerResources;

        private void Awake()
        {
            playerResources.nutsAndBoltsWatcher.OnValueChanged += UpdateNutsAndBoltsTmpu;
            playerResources.idleScientistsWatcher.OnValueChanged += UpdateScientistsTmpu;
            playerResources.busyScientistsWatcher.OnValueChanged += UpdateScientistsTmpu;
        }

        private void Start()
        {
            UpdateNutsAndBoltsTmpu();
            UpdateScientistsTmpu();
        }

        private void OnDestroy()
        {
            playerResources.nutsAndBoltsWatcher.OnValueChanged -= UpdateNutsAndBoltsTmpu;
            playerResources.idleScientistsWatcher.OnValueChanged -= UpdateScientistsTmpu;
            playerResources.busyScientistsWatcher.OnValueChanged -= UpdateScientistsTmpu;
        }

        [Inject]
        public void Construct(PlayerResources playerResources)
        {
            this.playerResources = playerResources;
        }

        private void UpdateNutsAndBoltsTmpu()
        {
            nutsAndBoltsTmpu.text = $"Nuts and Bolts: {playerResources.NutsAndBolts}";
        }

        private void UpdateScientistsTmpu()
        {
            scientistsTmpu.text = $"Scientists: {playerResources.IdleScientists} idle, {playerResources.BusyScientists} busy";
        }
    }
}