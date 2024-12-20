﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cannedenuum.UnityUtils.ValueChangeWatcher
{
    public class ValueChangeWatcher<T>
    {
        private T cachedValue;

        public ValueChangeWatcher() { }

        public ValueChangeWatcher(T cachedValue)
        {
            this.cachedValue = cachedValue;
        }

        public event Action OnValueChanged;
        public event Action<T> OnValueChangedNewValue;
        public event Action<T, T> OnValueChangedOldNewValue;

        public T Value
        {
            get => cachedValue;
            set
            {
                if (EqualityComparer<T>.Default.Equals(value, cachedValue)) return;
                T oldValue = cachedValue;
                cachedValue = value;

                OnValueChanged?.Invoke();
                OnValueChangedNewValue?.Invoke(cachedValue);
                OnValueChangedOldNewValue?.Invoke(oldValue, cachedValue);
            }
        }
    }
}