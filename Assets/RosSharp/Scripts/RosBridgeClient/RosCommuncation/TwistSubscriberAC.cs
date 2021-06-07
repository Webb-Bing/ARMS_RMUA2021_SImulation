using System.ComponentModel;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
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
    public class TwistSubscriberAC : UnitySubscriber<MessageTypes.Roborts.TwistAccel>
    {
        public Transform SubscribedTransform;
        public Rigidbody Robot;
        public int scale = 100;

        private float previousRealTime;
        public Vector3 linearVelocity;
        public Vector3 angularVelocity;
        public Vector3 linearAcceleration;
        public Vector3 angularAcceleration;
        private bool isMessageReceived;


        public float angle;
        public float cos;
        public float sin;
        public float vx;
        public float vy;
        public float vz;


        protected override void Start()
        {
            base.Start();
        }

        protected override void ReceiveMessage(MessageTypes.Roborts.TwistAccel message)
        {
            linearVelocity = ToVector3(message.twist.linear).Ros2Unity();
            angularVelocity = -ToVector3(message.twist.angular).Ros2Unity();
            linearAcceleration = ToVector3(message.accel.linear).Ros2Unity();
            angularAcceleration= ToVector3(message.accel.angular).Ros2Unity();
            isMessageReceived = true;
        }

        private static Vector3 ToVector3(MessageTypes.Geometry.Vector3 geometryVector3)
        {
            return new Vector3((float)geometryVector3.x, (float)geometryVector3.y, (float)geometryVector3.z);
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
            else
            {
                // Robot.velocity = new Vector3(0,0,0);
                // Robot.angularVelocity = new Vector3(0,0,0);
            }
            previousRealTime = Time.realtimeSinceStartup;
        }
        private void ProcessMessage()
        {
            // float deltaTime = Time.realtimeSinceStartup - previousRealTime;
            Vector3 rotation = SubscribedTransform.rotation.eulerAngles;
            angle = rotation[1]/180.0f*3.1416f;
            cos = Mathf.Cos(angle);
            sin = Mathf.Sin(angle);
            vx = linearVelocity.x;
            vy = linearVelocity.y;
            vz = linearVelocity.z;
            float z = linearVelocity.z*Mathf.Cos(angle)-linearVelocity.x*Mathf.Sin(angle);
            float x = linearVelocity.z*Mathf.Sin(angle)+linearVelocity.x*Mathf.Cos(angle);
            Robot.velocity = new Vector3(x*scale,0,z*scale);
            Robot.angularVelocity = angularVelocity;

            // float za = linearAcceleration.z*Mathf.Cos(angle)-linearAcceleration.x*Mathf.Sin(angle);
            // float xa = linearAcceleration.z*Mathf.Sin(angle)+linearAcceleration.x*Mathf.Cos(angle);
            // Vector3 direction =  new Vector3(xa*scale,0,za*scale);
            // Robot.AddForce(direction*Robot.mass)


            Robot.AddRelativeForce(linearAcceleration*Robot.mass);
            Robot.AddRelativeTorque(angularAcceleration*Robot.mass);


            // SubscribedTransform.Translate(linearVelocity * deltaTime  *scale);
            // SubscribedTransform.Rotate(Vector3.forward, angularVelocity.x * deltaTime);
            // SubscribedTransform.Rotate(Vector3.up, angularVelocity.y * deltaTime);
            // SubscribedTransform.Rotate(Vector3.left, angularVelocity.z * deltaTime);

            isMessageReceived = false;
        }
    }
}