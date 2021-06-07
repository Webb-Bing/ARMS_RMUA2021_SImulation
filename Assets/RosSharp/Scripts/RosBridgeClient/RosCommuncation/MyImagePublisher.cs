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
using System.Collections.Generic;
using System;

namespace RosSharp.RosBridgeClient
{
    public class MyImagePublisher : UnityPublisher<MessageTypes.Sensor.Image>
    {
        public Camera ImageCamera;
        public string FrameId = "Camera"; //  should be used for tf
        public int resolutionWidth = 1280;
        public int resolutionHeight = 1024;
        public int step = 3840;
        [Range(0, 100)]
        public int qualityLevel = 50;
        public int size;


        private MessageTypes.Sensor.Image message;
        private Texture2D texture2D;
        private Rect rect;
        float time;
        

        protected override void Start()
        {
            base.Start();
            InitializeGameObject();
            InitializeMessage();
            Camera.onPostRender += UpdateImage;
            time = 0;
        }

        private void UpdateImage(Camera _camera)
        {
            if (texture2D != null && _camera == this.ImageCamera)
                UpdateMessage();
        }

        private void InitializeGameObject()
        {
            texture2D = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
            //picture will draw from 0,0 and go rw on width and rh on height
            rect = new Rect(0, 0, resolutionWidth, resolutionHeight);
            // rect = new Rect(0, resolutionHeight , resolutionWidth , -resolutionHeight);
            ImageCamera.targetTexture = new RenderTexture(resolutionWidth, resolutionHeight, 24);

            
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Sensor.Image();
            message.header.frame_id = FrameId;
            message.height = (uint)resolutionHeight;
            message.width = (uint)resolutionWidth;
            message.encoding = "rgb8";
            // message.format = "jpeg";
            message.step = (uint)step;

        }

        private void UpdateMessage()
        {
            // message.header.Update();
            message.header.seq++;
            time += (float)0.1;
            message.header.stamp.secs = (uint)time;
            message.header.stamp.nsecs = (uint)(1e9 * (time - message.header.stamp.secs));
            // texture2D.ReadPixels(rect, 0, 0);
            texture2D.ReadPixels(rect, 0, 0);
            // texture2D = FlipTexture(texture2D);
            // texture2D.GetRawTextureData();
            byte[] pixs = texture2D.GetRawTextureData();
            List<byte> result = new List<byte>();
            for(int row=resolutionHeight-1;row>-1;row--)
            {
                byte[] temp = new byte[step];
                Array.Copy(pixs, row*step, temp, 0, step);
                result.AddRange(temp);
            }
                
            message.data = result.ToArray();
            // message.data = texture2D.EncodeToJPG(qualityLevel);
            size = message.data.Length;
            Publish(message);
        }
    }
}
