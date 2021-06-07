using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class RobotBonusPublisher : UnityPublisher<MessageTypes.Roborts.RobotBonus>
    {
        private MessageTypes.Roborts.RobotBonus robotBonus_msg;

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
            robotBonus_msg = new MessageTypes.Roborts.RobotBonus();
            robotBonus_msg.bonus = false;
        }

        private void UpdateMessage()
        {
            robotBonus_msg.bonus = robotStatus.Bonus;
            Publish(robotBonus_msg);
        }
    }
}