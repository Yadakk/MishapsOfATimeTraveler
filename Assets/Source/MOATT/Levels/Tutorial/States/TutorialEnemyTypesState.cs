using MOATT.Levels.BillboardGroup;
using MOATT.Levels.Enemies;
using MOATT.Levels.Tiles;
using MOATT.Levels.Waves;
using MOATT.Levels.Waves.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTimers;
using TMPro;
using UnityEngine;
using static UnityEngine.Random;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialEnemyTypesState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialEarningNutsAndBoltsState nextState;
        private readonly WaveStateMachine waveStateMachine;
        private readonly SpawnerTileFacade[] spawners;
        private readonly Timer timer;
        private readonly Settings settings;
        private readonly BillboardGroupFacade billboardGroup;

        private int enemyIndex = 0;

        public TutorialEnemyTypesState(TutorialWindow tutorialWindow, TutorialEarningNutsAndBoltsState nextState, WaveStateMachine waveStateMachine, TileFacade[] tiles, Timer timer, Settings settings, BillboardGroupFacade billboardGroup)
        {
            this.tutorialWindow = tutorialWindow;
            this.nextState = nextState;
            this.waveStateMachine = waveStateMachine;
            spawners = tiles.OfType<SpawnerTileFacade>().ToArray();
            this.timer = timer;
            this.settings = settings;
            this.billboardGroup = billboardGroup;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("Regular - just moves to main tower.");
            sb.AppendLine("Heavy - slow but more health and attack.");
            sb.AppendLine("Destroyer - stops to attack buildings you placed.");
            sb.AppendLine("Helicopter - attacks your buildings without stopping. Once it reaches your main tower, deals damage equivalent to it's health and disappears.");
            sb.AppendLine("Jumper - fast and weak. Can jump over fences once.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(nextState));
        }

        public override void Dispose()
        {
            waveStateMachine.SetState<Delay>();
        }

        public override void Update()
        {
            if (timer.Elapsed < settings.spawnInterval) return;
            if (enemyIndex >= settings.displayEnemies.Length) return;
            var enemy = spawners[Range(0, spawners.Length)].Spawn(settings.displayEnemies[enemyIndex]);

            GameObject nameBillboard = UnityEngine.Object.Instantiate(settings.nameBillboard, enemy.transform);
            TextMeshProUGUI tmpuBillboard = nameBillboard.GetComponent<TextMeshProUGUI>();
            tmpuBillboard.text = enemy.Name;

            var billboard = billboardGroup.AddBillboard(enemy.BillboardSource, nameBillboard);

            enemy.OnDestroyed += () =>
            {
                if (billboard.gameObject == null) return;
                UnityEngine.Object.Destroy(billboard.gameObject);
            };

            enemyIndex++;
            timer.Reset();
        }

        [Serializable]
        public class Settings
        {
            public float spawnInterval = 3f;
            public EnemyFacade[] displayEnemies;
            public GameObject nameBillboard;
        }
    }
}
