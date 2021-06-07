using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class RobotDamagePublisher : UnityPublisher<MessageTypes.Roborts.RobotDamage>
    {
        private MessageTypes.Roborts.RobotDamage robotDamage_msg;

        // robot damage
        const byte ARMOR = 0;
        const byte OFFLINE = 1;
        const byte EXCEED_HEAT = 2;
        const byte FORWARD = 0;
        const byte LEFT = 1;
        const byte BACKWARD = 2;
        const byte RIGHT = 3;
        byte EXCEED_POWER = 3;
        
        private byte damage_source;
        private byte damage_type;

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
            robotDamage_msg = new MessageTypes.Roborts.RobotDamage();
        }

        private void UpdateMessage()
        {
            robotDamage_msg.damage_source = 8;
            robotDamage_msg.damage_type = 8;
            Publish(robotDamage_msg);
        }

        public void SendDamageMessage(byte damage_source, byte damage_type)
        {
            robotDamage_msg.damage_source = damage_source;
            robotDamage_msg.damage_type = damage_type;
            Publish(robotDamage_msg);
        }
    }
}