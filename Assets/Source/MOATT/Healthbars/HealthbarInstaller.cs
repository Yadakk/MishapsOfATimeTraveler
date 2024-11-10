using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Healthbars
{
    using Health;

    public class HealthbarInstaller : MonoInstaller
    {
        private HealthModel healthModel;

        [Inject]
        public void Construct(HealthModel healthModel)
        {
            this.healthModel = healthModel;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(healthModel);
            Container.BindInterfacesAndSelfTo<HealthbarVM>().AsSingle();
        }
    }
}
