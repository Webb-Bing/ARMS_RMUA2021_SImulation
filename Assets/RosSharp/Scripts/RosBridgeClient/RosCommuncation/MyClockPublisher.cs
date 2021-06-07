using System.Reflection;
using System.Security.Principal;
using System.Data;

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class MyClockPublisher : UnityPublisher<MessageTypes.Rosgraph.Clock>{
        private MessageTypes.Std.Time stamp;

        private MessageTypes.Rosgraph.Clock clock;

        float time;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
            time = 0;
        }

        private void Update()
        {
            UpdateMessage();
        }
        private void InitializeMessage()
        {
            clock = new MessageTypes.Rosgraph.Clock();
            stamp = new MessageTypes.Std.Time();

            // Debug.Log(stamp);
        }
        private void UpdateMessage()
        {
            time += (float)0.1;
            stamp.secs = (uint)time;
            stamp.nsecs = (uint)(1e9 * (time - stamp.secs));
            clock.clock = stamp;
            Publish(clock); 
            //print("hello");
            //print(stamp.secs);
        }
    }
}