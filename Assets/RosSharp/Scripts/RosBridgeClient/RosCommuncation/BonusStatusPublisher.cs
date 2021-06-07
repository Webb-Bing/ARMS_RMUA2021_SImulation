using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class BonusStatusPublisher : UnityPublisher<MessageTypes.Roborts.BonusStatus>
    {
        private MessageTypes.Roborts.BonusStatus bonusStatus_msg;

        public GameObject refereeSystem;
        private RefereeSystemBehavior refereeSystemBehavior;
        
        protected override void Start()
        {
            base.Start();
            refereeSystem = gameObject;
            refereeSystemBehavior = refereeSystem.GetComponent<RefereeSystemBehavior>();
            InitializeMessage();
        }

        private void Update()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            bonusStatus_msg = new MessageTypes.Roborts.BonusStatus();
            bonusStatus_msg.blue_bonus = 0;
            bonusStatus_msg.red_bonus = 0;
        }

        private void UpdateMessage()
        {
            Publish(bonusStatus_msg);
        }
    }
}