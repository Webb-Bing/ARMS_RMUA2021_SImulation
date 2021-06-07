using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class GameSurvivorPublisher : UnityPublisher<MessageTypes.Roborts.GameSurvivor>
    {
        private MessageTypes.Roborts.GameSurvivor gameSurvivor_msg;

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
            gameSurvivor_msg = new MessageTypes.Roborts.GameSurvivor();
            gameSurvivor_msg.blue3 = true;
            gameSurvivor_msg.blue4 = true;
            gameSurvivor_msg.red3 = true;
            gameSurvivor_msg.red4 = true;
        }

        private void UpdateMessage()
        {
            if (gameSurvivor_msg.blue3 && refereeSystemBehavior.B1Status.isDead)
            {
                gameSurvivor_msg.blue3 = false;
            }
            
            if (gameSurvivor_msg.blue4 && refereeSystemBehavior.B2Status.isDead)
            {
                gameSurvivor_msg.blue4 = false;
            }
            
            if (gameSurvivor_msg.red3 && refereeSystemBehavior.R1Status.isDead)
            {
                gameSurvivor_msg.red3 = false;
            }
            
            if (gameSurvivor_msg.red4 && refereeSystemBehavior.R2Status.isDead)
            {
                gameSurvivor_msg.red4 = false;
            }
            Publish(gameSurvivor_msg);
        }
    }
}