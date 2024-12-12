using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.UnityUtils.ValueChangeWatcher;

namespace MOATT.Levels.Economics
{
    public class PlayerResources : Zenject.IInitializable
    {
        public ValueChangeWatcher<int> nutsAndBoltsWatcher = new();
        public ValueChangeWatcher<int> idleScientistsWatcher = new();
        public ValueChangeWatcher<int> busyScientistsWatcher = new();

        private readonly Settings settings;

        public int NutsAndBolts { get => nutsAndBoltsWatcher.Value; set => nutsAndBoltsWatcher.Value = value; }
        public int IdleScientists { get => idleScientistsWatcher.Value; set => idleScientistsWatcher.Value = value; }
        public int BusyScientists { get => busyScientistsWatcher.Value; set => busyScientistsWatcher.Value = value; }

        public int MaxScientists => settings.maxScientists;

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
            public int maxScientists = 10;
        }
    }
}