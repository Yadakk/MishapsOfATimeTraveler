using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HologramDisplayers
{
    public class HologramDisplayer : MonoBehaviour
    {
        public Material hologramMaterial;

        private Transform displayedModel;

        public void SetActive(bool isActive) => gameObject.SetActive(isActive);

        public void SetModel(GameObject model)
        {
            if (displayedModel != null) Destroy(displayedModel.gameObject);
            displayedModel = new GameObject(model.name).transform;
            displayedModel.SetParent(transform);
            var goTransform = model.transform;
            AddTransform(goTransform, displayedModel);
        }

        private void AddTransform(Transform source, Transform target)
        {
            target.SetLocalPositionAndRotation(source.localPosition, source.localRotation);
            target.localScale = source.localScale;

            if (source.TryGetComponent<MeshFilter>(out var sourceFilter))
            {
                var targetFilter = target.gameObject.AddComponent<MeshFilter>();
                targetFilter.mesh = sourceFilter.sharedMesh;

                var targetRenderer = target.gameObject.AddComponent<MeshRenderer>();
                targetRenderer.material = hologramMaterial;
            }

            for (int i = 0; i < source.childCount; i++)
            {
                var newSource = source.GetChild(i);
                var newTarget = new GameObject(newSource.name).transform;
                newTarget.SetParent(target);

                AddTransform(newSource, newTarget);
            }
        }
    }
}
