using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class RobotHeatPublisher : UnityPublisher<MessageTypes.Roborts.RobotHeat>
    {
        private MessageTypes.Roborts.RobotHeat robotDamage_msg;

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
            robotDamage_msg = new MessageTypes.Roborts.RobotHeat();
        }

        private void UpdateMessage()
        {
            robotDamage_msg.chassis_current = robotStatus.ChassisCurrent;
            robotDamage_msg.chassis_power = robotStatus.ChassisPower;
            robotDamage_msg.chassis_power_buffer = robotStatus.ChassisPowerBuffer;
            robotDamage_msg.chassis_volt = robotStatus.ChassisVolt;
            robotDamage_msg.shooter_heat = (ushort) robotStatus.CurrentHeat;
            Publish(robotDamage_msg);
        }

    }
}