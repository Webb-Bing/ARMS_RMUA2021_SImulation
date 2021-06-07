using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class SupplierStatusPublisher : UnityPublisher<MessageTypes.Roborts.SupplierStatus>
    {
        private MessageTypes.Roborts.SupplierStatus supplierStatus_msg;

        public GameObject robot;
        RobotStatus robotStatus;
    }
}