using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TransformGrouping
{
    public class TransformGrouperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TransformGrouper>().FromComponentInHierarchy().AsSingle();
        }
    }
}
