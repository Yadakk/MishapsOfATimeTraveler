using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using RTS_Cam;

namespace MOATT.Levels.LevelCamera
{
    public class RTSCameraRotater : ITickable
    {
        private readonly RTS_Camera rtsCamera;
        private readonly Transform rtsCameraTransform;
        private readonly Settings settings;

        public RTSCameraRotater(RTS_Camera rtsCamera, Settings settings = null)
        {
            this.rtsCamera = rtsCamera;
            rtsCameraTransform = rtsCamera.transform;
            this.settings = settings;
        }

        public void Tick()
        {
            float rtsCameraHeightInverseLerp = Mathf.InverseLerp(
                rtsCamera.minHeight, rtsCamera.maxHeight,
                rtsCameraTransform.position.y);
            float rotationAngleLerp = Mathf.Lerp(settings.minAngle, settings.maxAngle, rtsCameraHeightInverseLerp);

            rtsCameraTransform.rotation = Quaternion.Lerp(
                rtsCameraTransform.rotation,
                Quaternion.Euler(
                    rotationAngleLerp,
                    rtsCameraTransform.rotation.eulerAngles.y,
                    rtsCameraTransform.rotation.eulerAngles.z), Time.deltaTime * settings.deltaTimeLerpMultiplier
                );
        }

        [Serializable]
        public class Settings
        {
            public float minAngle = 10f;
            public float maxAngle = 80f;
            public float deltaTimeLerpMultiplier = 5f;
        }
    }
}
