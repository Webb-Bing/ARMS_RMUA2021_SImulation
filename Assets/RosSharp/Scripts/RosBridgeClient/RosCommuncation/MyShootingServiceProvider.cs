/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

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

using System.Collections.Generic;
using RosApi = RosSharp.RosBridgeClient.MessageTypes.Roborts;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class MyShootingServiceProvider : UnityServiceProvider<RosApi.ShootCmdRequest, RosApi.ShootCmdResponse>
    {
        public int mode;
        public int number;
        int Speed = 250;
        public Rigidbody Projectile;
        public Transform LaunchPoint;
        
        protected override bool ServiceCallHandler(RosApi.ShootCmdRequest request, out RosApi.ShootCmdResponse response)
        {
            mode = request.mode;
            
            if(mode==0)
            {
                number = 0;
                response = new RosApi.ShootCmdResponse(true);
                return true;

            }
            else if (mode == 1)
            {
                number = 1;
                response = new RosApi.ShootCmdResponse(true);
                return true;
            }
            // continually shooting 
            else if (mode == 2)
            {
                number = request.number;
                response = new RosApi.ShootCmdResponse(true);
                return true;
            }
            response = new RosApi.ShootCmdResponse();
            return false;
        }

        void Update()
        {
            if(number!=0)
            {
                Rigidbody clone;
                clone = (Rigidbody)Instantiate(Projectile, LaunchPoint.position, LaunchPoint.rotation);
                clone.velocity = transform.TransformDirection(Vector3.forward * Speed);
                number--;
            }
        }
    }
}