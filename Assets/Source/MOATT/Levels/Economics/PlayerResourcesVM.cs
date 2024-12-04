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
            playerResources.nutsAndBolts.OnValueChanged += UpdateNutsAndBoltsTmpu;
            playerResources.scientists.OnValueChanged += UpdateScientistsTmpu;
        }

        private void Start()
        {
            UpdateNutsAndBoltsTmpu();
            UpdateScientistsTmpu();
        }

        private void OnDestroy()
        {
            playerResources.nutsAndBolts.OnValueChanged -= UpdateNutsAndBoltsTmpu;
            playerResources.scientists.OnValueChanged -= UpdateScientistsTmpu;
        }

        [Inject]
        public void Construct(PlayerResources playerResources)
        {
            this.playerResources = playerResources;
        }

        private void UpdateNutsAndBoltsTmpu()
        {
            nutsAndBoltsTmpu.text = $"Nuts and Bolts: {playerResources.nutsAndBolts.Value}";
        }

        private void UpdateScientistsTmpu()
        {
            scientistsTmpu.text = $"Scientists: {playerResources.scientists.Value}";
        }
    }
}