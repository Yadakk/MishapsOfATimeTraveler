using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.UnityUtils.ValueChangeWatcher;

namespace MOATT.Levels.Economics
{
    public class PlayerResources : Zenject.IInitializable
    {
        public ValueChangeWatcher<int> nutsAndBoltsWatcher = new();
        public ValueChangeWatcher<int> scientistsWatcher = new();

        private readonly Settings settings;

        public int NutsAndBolts { get => nutsAndBoltsWatcher.Value; set => nutsAndBoltsWatcher.Value = value; }
        public int Scientists { get => scientistsWatcher.Value; set => scientistsWatcher.Value = value; }

        public PlayerResources(Settings settings)
        {
            this.settings = settings;
        }

        public void Initialize()
        {
            NutsAndBolts = settings.startingNutsAndBolts;
        }

        [System.Serializable]
        public class Settings
        {
            public int startingNutsAndBolts = 150;
        }
    }
}