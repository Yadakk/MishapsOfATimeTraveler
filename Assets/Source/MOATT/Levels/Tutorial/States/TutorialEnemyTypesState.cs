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
        private readonly Settings settings;
        private readonly BillboardGroupFacade billboardGroup;

        private int enemyIndex = 0;

        public TutorialEnemyTypesState(TutorialWindow tutorialWindow, TutorialEarningNutsAndBoltsState nextState, WaveStateMachine waveStateMachine, TileFacade[] tiles, Settings settings, BillboardGroupFacade billboardGroup)
        {
            this.tutorialWindow = tutorialWindow;
            this.nextState = nextState;
            this.waveStateMachine = waveStateMachine;
            spawners = tiles.OfType<SpawnerTileFacade>().ToArray();
            this.settings = settings;
            this.billboardGroup = billboardGroup;
        }

        public override void Start()
        {
            tutorialWindow.SetTextContent("Here are the enemy types. Press Next to see next enemy.");
            tutorialWindow.SetNextButtonEvent(SpawnNextEnemy);
        }

        public override void Dispose()
        {
            waveStateMachine.SetState<Delay>();
        }

        private void SpawnNextEnemy()
        {
            if (enemyIndex >= settings.displayEnemies.Length)
            {
                tutorialWindow.SetState(nextState);
                return;
            }

            var enemy = spawners[Range(0, spawners.Length)].Spawn(settings.displayEnemies[enemyIndex]);

            GameObject nameBillboard = UnityEngine.Object.Instantiate(settings.nameBillboard, enemy.transform);
            TextMeshProUGUI tmpuBillboard = nameBillboard.GetComponent<TextMeshProUGUI>();
            tmpuBillboard.text = enemy.Name;

            var billboard = billboardGroup.AddBillboard(enemy.BillboardSource, nameBillboard);

            enemy.OnDestroyed += () =>
            {
                if (billboard == null) return;
                if (billboard.gameObject == null) return;
                UnityEngine.Object.Destroy(billboard.gameObject);
            };

            string windowText = string.Empty;

            switch (enemyIndex)
            {
                case 0: windowText = "Regular - just moves to main tower."; break;
                case 1: windowText = "Destroyer - stops to attack buildings you placed."; break;
                case 2: windowText = "Heavy - slow but more health and attack."; break;
                case 3: windowText = "Helicopter - attacks your buildings without stopping. Once it reaches your main tower, deals damage equivalent to it's health and disappears."; break;
                case 4: windowText = "Jumper - fast and weak. Can jump over fences once."; break;
            }

            tutorialWindow.SetTextContent(windowText);

            enemyIndex++;
        }

        [Serializable]
        public class Settings
        {
            public EnemyFacade[] displayEnemies;
            public GameObject nameBillboard;
        }
    }
}
