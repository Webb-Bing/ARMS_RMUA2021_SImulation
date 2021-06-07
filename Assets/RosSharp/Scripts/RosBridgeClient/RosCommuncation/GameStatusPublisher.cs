using System;
using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class GameStatusPublisher : UnityPublisher<MessageTypes.Roborts.GameStatus>
    {
        private MessageTypes.Roborts.GameStatus gameStatus_msg;

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
            gameStatus_msg = new MessageTypes.Roborts.GameStatus();
            gameStatus_msg.game_status = 0;
            gameStatus_msg.remaining_time = 66;
        }

        private void UpdateMessage()
        {
            ushort deltaTime = (ushort) (Math.Floor(refereeSystemBehavior.TimeLimit) - Math.Floor(refereeSystemBehavior.GameTime));
            gameStatus_msg.remaining_time = deltaTime;
            gameStatus_msg.game_status = (byte)refereeSystemBehavior.gameStatus;
            Publish(gameStatus_msg);
        }
    }
}