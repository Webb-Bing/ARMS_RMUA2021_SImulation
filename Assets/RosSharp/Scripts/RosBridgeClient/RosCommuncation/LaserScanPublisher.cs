using System.Security.AccessControl;
using System.Net.Http;
/*
© Siemens AG, 2018
Author: Berkay Alp Cakal (berkay_alp.cakal.ct@siemens.com)

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

using UnityEngine;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;


namespace RosSharp.RosBridgeClient
{
    public class LaserScanPublisher : UnityPublisher<MessageTypes.Sensor.LaserScan>
    {
        public LaserScanReader laserScanReader;
        public string FrameId = "Unity";

        private MessageTypes.Sensor.LaserScan message;
        private float scanPeriod;
        private float previousScanTime = 0;
        public float scale = 100.0f;
                
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            if (Time.realtimeSinceStartup >= previousScanTime + scanPeriod)
            {
                UpdateMessage();
                previousScanTime = Time.realtimeSinceStartup;
            }
        }

        private void InitializeMessage()
        {
            scanPeriod = (float)laserScanReader.samples / (float)laserScanReader.update_rate;

            message = new MessageTypes.Sensor.LaserScan
            {
                header = new MessageTypes.Std.Header { frame_id = FrameId },
                angle_min       = laserScanReader.angle_min,
                angle_max       = laserScanReader.angle_max,
                angle_increment = laserScanReader.angle_increment,
                time_increment  = laserScanReader.time_increment,
                range_min       = laserScanReader.range_min/scale,
                range_max       = laserScanReader.range_max/scale,
                ranges          = laserScanReader.ranges,      
                intensities     = laserScanReader.intensities
            };
        }

        private void UpdateMessage()
        {
            message.header.Update();
            // message.ranges = laserScanReader.Scan();
            float[]  temp = laserScanReader.Scan();
            //int[] indexs = new int[temp.Length];

            // for (int i = 0; i < temp.Length; i++)
            // {
            //     message.ranges[i] = temp[i] / scale ;
            // }
            // float[]  temp = laserScanReader.Scan();
            int[] indexs = Enumerable.Range(0, temp.Length-1).ToArray();
            Parallel.ForEach(indexs, (i)=>
            {
                message.ranges[i] = temp[i] / scale ;
            });




            Publish(message);
        }
    }
}
