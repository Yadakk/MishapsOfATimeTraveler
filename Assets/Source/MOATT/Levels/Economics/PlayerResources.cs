using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.UnityUtils.ValueChangeWatcher;
using TimeTimers;
using Zenject;

namespace MOATT.Levels.Economics
{
    public class PlayerResources : Zenject.IInitializable, ITickable
    {
        public ValueChangeWatcher<int> nutsAndBoltsWatcher = new();
        public ValueChangeWatcher<int> idleScientistsWatcher = new();
        public ValueChangeWatcher<int> busyScientistsWatcher = new();

        private Timer timer;
        private int passiveIncomeRate;

        private readonly Settings settings;

        public int NutsAndBolts { get => nutsAndBoltsWatcher.Value; set => nutsAndBoltsWatcher.Value = value; }
        public int IdleScientists { get => idleScientistsWatcher.Value; set => idleScientistsWatcher.Value = value; }
        public int BusyScientists { get => busyScientistsWatcher.Value; set => busyScientistsWatcher.Value = value; }

        public int MaxScientists => settings.maxScientists;

        public PlayerResources(Settings settings, Timer timer)
        {
            this.settings = settings;
            this.timer = timer;
            this.passiveIncomeRate = settings.passiveIncomeRate;
        }

        public void Initialize()
        {
            NutsAndBolts = settings.startingNutsAndBolts;
        }
        public void Tick()
        {
            if (timer.Elapsed < passiveIncomeRate)
                return;
            NutsAndBolts += 50;
            timer.Reset();
        }

        [System.Serializable]
        public class Settings
        {
            public int startingNutsAndBolts = 150;
            public int maxScientists = 10;
            public int passiveIncomeRate = 30;
        }
    }
}