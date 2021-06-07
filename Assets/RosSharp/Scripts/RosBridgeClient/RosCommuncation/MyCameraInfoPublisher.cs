using System.Reflection;
using System.Security.Principal;
using System.Data;

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class MyCameraInfoPublisher : UnityPublisher<MessageTypes.Sensor.CameraInfo>{
        // private MessageTypes.Std.Time stamp;

        private MessageTypes.Sensor.CameraInfo message;
        public string FrameId = "Camera"; //  should be the same as the one in the MyImagePublisher.cs
        public int resolutionWidth = 1280;//  should be the same as the one in the MyImagePublisher.cs
        public int resolutionHeight = 1024;//  should be the same as the one in the MyImagePublisher.cs
        public string distortion_model = "plumb_bob";

        float time;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            UpdateMessage();
        }
        private void InitializeMessage()
        {
            message = new MessageTypes.Sensor.CameraInfo();
            message.header.frame_id = FrameId;
            message.height = (uint)resolutionHeight;
            message.width = (uint)resolutionWidth;
            message.distortion_model = distortion_model;
            // message.D = {(double)0,(double)0,(double)0,(double)0,(double)0};
            // double[] d = new double[]
            message.D = new double[]{0,0,0,0,0};
            message.K = new double[]{0,0,0,0,0,0,0,0,1};
            message.R = new double[]{1,0,0,0,1,0,0,0,1};
            message.P = new double[]{0,0,0,0,0,0,0,0,0,0,1,0};
            message.binning_x = 0;
            message.binning_y = 0;
            time = 0;
            // stamp = new MessageTypes.Std.Time();

            // Debug.Log(stamp);
        }
        private void UpdateMessage()
        {
            message.header.seq++;
            time += (float)0.1;
            message.header.stamp.secs = (uint)time;
            message.header.stamp.nsecs = (uint)(1e9 * (time - message.header.stamp.secs));
            Publish(message); 
            // print("hello");
            // print(stamp.secs);
        }
    }
}