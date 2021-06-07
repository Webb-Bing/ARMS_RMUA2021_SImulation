using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class RobotShootPublisher : UnityPublisher<MessageTypes.Roborts.RobotShoot>
    {
        private MessageTypes.Roborts.RobotShoot robotShoot_msg;

        public GameObject robot;
        RobotStatus robotStatus;
        
        protected override void Start()
        {
            base.Start();
            if (robot == null)
            {
                Debug.Log("please attach robot obj");
            }

            robotStatus = robot.GetComponent<RobotStatus>();
            InitializeMessage();
        }

        private void Update()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            robotShoot_msg = new MessageTypes.Roborts.RobotShoot();
        }

        private void UpdateMessage()
        {
            robotShoot_msg.speed = robotStatus.CurrentLaunchSpeed;
            robotShoot_msg.frequency = (byte) robotStatus.CurrentLaunchFrequency;
            Publish(robotShoot_msg);
        }

    }
}