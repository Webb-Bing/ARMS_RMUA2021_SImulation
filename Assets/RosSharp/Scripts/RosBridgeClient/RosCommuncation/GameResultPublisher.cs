using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class GameResultPublisher : UnityPublisher<MessageTypes.Roborts.GameResult>
    {
        private MessageTypes.Roborts.GameResult gameResult_msg;

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
            gameResult_msg = new MessageTypes.Roborts.GameResult();
            gameResult_msg.result = 0;
        }

        private void UpdateMessage()
        {
            switch (refereeSystemBehavior.Winner)
            {
                case 1:
                    gameResult_msg.result = 2;
                    break;
                case 2:
                    gameResult_msg.result = 1;
                    break;
                case 3:
                    gameResult_msg.result = 3;
                    break;
                default:
                    break;
            }
            Publish(gameResult_msg);
        }
    }
}