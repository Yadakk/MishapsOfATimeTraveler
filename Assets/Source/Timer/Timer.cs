using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timers
{
    public class Timer
    {
        private float start;

        public Timer()
        {
            Reset();
        }

        public float Elapsed => start - Time.time;

        public void Reset()
        {
            start = Time.time;
        }
    }
}
