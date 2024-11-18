using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeTimers
{
    public class Timer
    {
        private float start;

        public Timer()
        {
            Reset();
        }

        public float Elapsed => Time.time - start;

        public void Reset()
        {
            start = Time.time;
        }
    }
}
