/*
© CentraleSupelec, 2017
Author: Dr. Jeremy Fix (jeremy.fix@centralesupelec.fr)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

// Adjustments to new Publication Timing and Execution Framework
// © Siemens AG, 2018, Dr. Martin Bischoff (martin.bischoff@siemens.com)

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class GimbalSubscriber : UnitySubscriber<MessageTypes.Roborts.GimbalAngle>
    {
        public Transform yawTransform;
        public Transform pitchTransform;
        public int scale = 100;

        private float previousRealTime;
        private bool isMessageReceived;

        public double yaw_angle;
        public double pitch_angle;
        public bool yaw_mode;
        public bool pitch_mode;


        protected override void Start()
        {
            base.Start();
        }

        protected override void ReceiveMessage(MessageTypes.Roborts.GimbalAngle message)
        {
            this.yaw_mode = message.yaw_mode;
            this.pitch_mode = message.pitch_mode;
            this.yaw_angle = message.yaw_angle;
            this.pitch_angle = message.pitch_angle;
            isMessageReceived = true;
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
            previousRealTime = Time.realtimeSinceStartup;
        }
        private void ProcessMessage()
        {
            float deltaTime = Time.realtimeSinceStartup - previousRealTime;

            double pitchEulerAngles = pitch_angle/3.14*180.0;
            pitchTransform.localEulerAngles = new Vector3((float)pitchEulerAngles, 0, 0);
            double yawEulerAngles = yaw_angle/3.14*180.0;
            yawTransform.localEulerAngles = new Vector3(0, (float)yawEulerAngles, 0);


            isMessageReceived = false;
        }
    }
}