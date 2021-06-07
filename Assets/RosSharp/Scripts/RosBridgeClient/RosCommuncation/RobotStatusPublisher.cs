using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    
    public class RobotStatusPublisher : UnityPublisher<MessageTypes.Roborts.RobotStatus>
    {
        private MessageTypes.Roborts.RobotStatus robotStatus_msg;

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
            robotStatus_msg = new MessageTypes.Roborts.RobotStatus();
        }
        private void UpdateMessage()
        {
            robotStatus_msg.id = robotStatus.RobotId;
            robotStatus_msg.remain_hp = (ushort)robotStatus.CurrentHp;
            robotStatus_msg.max_hp = (ushort)robotStatus.InitHp;
            robotStatus_msg.chassis_output = robotStatus.ChassisOutput;
            robotStatus_msg.gimbal_output = robotStatus.GimbalOutput;
            robotStatus_msg.shooter_output = robotStatus.ShooterOutput;
            robotStatus_msg.heat_cooling_limit = (ushort)robotStatus.BarrelHeatLimit1;
            robotStatus_msg.heat_cooling_rate = (ushort)robotStatus.CoolingRate;
            robotStatus_msg.level = robotStatus.Level;
            Publish(robotStatus_msg);
        }
        
    }
    
}