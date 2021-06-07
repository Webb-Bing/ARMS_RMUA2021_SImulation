using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class ProjectileSupplyPublisher : UnityPublisher<MessageTypes.Roborts.ProjectileSupply>
    {
        private MessageTypes.Roborts.ProjectileSupply projectileSupply_msg;

        public GameObject supplier;

        protected override void Start()
        {
            base.Start();
            if (supplier == null)
            {
                Debug.Log("please attach buffzone obj");
            }
            
            InitializeMessage();
        }

        private void Update()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            projectileSupply_msg = new MessageTypes.Roborts.ProjectileSupply();
        }

        private void UpdateMessage()
        {
            Publish(projectileSupply_msg);
        }
    }
}