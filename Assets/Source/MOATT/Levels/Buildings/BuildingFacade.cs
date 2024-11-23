using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;
    using Tiles;
    using System.Linq;
    using MOATT.Levels.UnitRange;

    public class BuildingFacade : MonoBehaviour
    {
        private HealthModel healthModel;

        private GameObjectContext goContext;

        public bool HasHealth => healthModel != null;
        public UnitRange BuildingRange { get; private set; }

        [Inject]
        public void Construct(
            [InjectOptional] BuildingTunables tunables,
            [InjectOptional] HealthModel healthModel,
            [InjectOptional] UnitRange buildingRange
            )
        {
            this.healthModel = healthModel;
            BuildingRange = buildingRange;

            tunables?.initTile.SetBuilding(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void Damage(float amount)
        {
            healthModel.CurrentHealth -= amount;
        }

        public T GetSOInstaller<T>() where T : ScriptableObjectInstaller
        {
            if (goContext == null) goContext = GetComponent<GameObjectContext>();
            return goContext.ScriptableObjectInstallers.OfType<T>().FirstOrDefault();
        }

        [System.Serializable]
        public class Settings
        {
            public TileBuilding.TileType canBePlacedOn;
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
