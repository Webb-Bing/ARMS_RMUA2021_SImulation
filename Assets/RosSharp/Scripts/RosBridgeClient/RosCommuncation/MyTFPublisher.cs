//http://wiki.ros.org/navigation/Tutorials/RobotSetup/Odom

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class MyTFPublisher : UnityPublisher<MessageTypes.Tf2.TFMessage>{
        public string FrameId = "/odom";
        public string ChildFrameId = "/base_link";

        private MessageTypes.Tf2.TFMessage message;
        private MessageTypes.Geometry.TransformStamped[] transforms;
        private float previousRealTime;

        // public Rigidbody SubscribedRigidbody;
        public Transform SubscribedTransform;

        public float scale = 100f;

        public Transform InitTransform;

        
        protected override void Start()
        {
            base.Start();
            // InitTransform = SubscribedTransform;
            InitializeMessage();
        }

        private void Update()
        {
            UpdateMessage();
        }
        private void InitializeMessage()
        {
            transforms = new MessageTypes.Geometry.TransformStamped[]{
                new MessageTypes.Geometry.TransformStamped()
            };
            transforms[0].header.frame_id = FrameId;
            transforms[0].child_frame_id = ChildFrameId;
            message = new MessageTypes.Tf2.TFMessage(transforms);
        }
        private void UpdateMessage()
        {

            message.transforms[0].header.Update();
            message.transforms[0].transform.translation = 
            // createTranslation((SubscribedTransform.position.x - InitTransform.position.x) / scale, 
            // (SubscribedTransform.position.z - InitTransform.position.z)/scale, 0);
            createTranslation((SubscribedTransform.position.z - InitTransform.position.z) / scale, 
            -(SubscribedTransform.position.x - InitTransform.position.x)/scale, 0);
            // message.transforms[0].transform.rotation = createQuaternionMsgFromYaw(th);

            

            Quaternion q = new Quaternion();
            q = SubscribedTransform.rotation * Quaternion.Inverse(InitTransform.rotation);

            message.transforms[0].transform.rotation = createQuaternion(q);

            // lastPos = transform.position;
            // lastRota = transforms.rotation;

            Publish(message);
        }
        private MessageTypes.Geometry.Vector3 createTranslation(float x,float y,float z)
        {
            MessageTypes.Geometry.Vector3 v3 = new MessageTypes.Geometry.Vector3();
            v3.x = x;//x;
            v3.y = y;//y;
            v3.z = 0;//z;
            // Debug.Log(v3);
            return v3;
        }
        private MessageTypes.Geometry.Quaternion createQuaternion(Quaternion input){
            MessageTypes.Geometry.Quaternion q = new MessageTypes.Geometry.Quaternion();
            q.z = -input.y;
            q.y = 0;
            q.x = 0;
            q.w = input.w;
            return q;   

        }
        private MessageTypes.Geometry.Quaternion createQuaternionMsgFromYaw(float th){
            Quaternion odom_quat = Quaternion.Euler(0, th*180/3.14f, 0);
            // Debug.Log(odom_quat);
            MessageTypes.Geometry.Quaternion q = new MessageTypes.Geometry.Quaternion();
            q.x = 0;
            q.y = 0;
            q.z = odom_quat.y;
            q.w = odom_quat.w;
            // Debug.Log(q);
            return q;   
        }
        // private static MessageTypes.Geometry.Vector3 linearVelocityToGeometryVector3(Vector3 vector3)
        // {
        //     MessageTypes.Geometry.Vector3 geometryVector3 = new MessageTypes.Geometry.Vector3();
        //     geometryVector3.x = vector3.x;
        //     geometryVector3.y = vector3.z;
        //     geometryVector3.z = 0;
        //     return geometryVector3;
        // }

        //  private static MessageTypes.Geometry.Vector3 angularVelocityToGeometryVector3(Vector3 vector3)
        // {
        //     MessageTypes.Geometry.Vector3 geometryVector3 = new MessageTypes.Geometry.Vector3();
        //     geometryVector3.x = 0;
        //     geometryVector3.y = 0;
        //     geometryVector3.z = -vector3.z;
        //     return geometryVector3;
        // }


        // private MessageTypes.Geometry.Vector3 GetGeometryPoint(Vector3 position)
        // {
        //     MessageTypes.Geometry.Vector3 geometryPoint = new MessageTypes.Geometry.Vector3();
        //     geometryPoint.x = position.x;
        //     geometryPoint.y = -position.y;
        //     geometryPoint.z = position.z;
        //     return geometryPoint;
        // }

        // private MessageTypes.Geometry.Quaternion GetGeometryQuaternion(Quaternion quaternion)
        // {
        //     MessageTypes.Geometry.Quaternion geometryQuaternion = new MessageTypes.Geometry.Quaternion();
        //     geometryQuaternion.x = quaternion.x;
        //     geometryQuaternion.y = -quaternion.y;
        //     geometryQuaternion.z = quaternion.z;
        //     geometryQuaternion.w = quaternion.w;
        //     return geometryQuaternion;
        // }

    }
}