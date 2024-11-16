﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TransformGrouping
{
    public class TransformGrouper : MonoBehaviour
    {
        private readonly List<Transform> groups = new();

        public Transform GetGroup(string name)
        {
            var matchingGroup = groups.FirstOrDefault(group => group.name == name);

            if (matchingGroup != null)
            {
                return matchingGroup;
            }

            Transform newGroup = new GameObject(name).transform;
            newGroup.SetParent(transform.root);
            groups.Add(newGroup);
            return newGroup;
        }
    }
}
