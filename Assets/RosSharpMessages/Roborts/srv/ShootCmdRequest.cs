/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */



namespace RosSharp.RosBridgeClient.MessageTypes.Roborts
{
    public class ShootCmdRequest : Message
    {
        public const string RosMessageName = "roborts_msgs/ShootCmd";

        public const byte STOP = 0;
        public const byte ONCE = 1;
        public const byte CONTINUOUS = 2;
        public byte mode { get; set; }
        public byte number { get; set; }

        public ShootCmdRequest()
        {
            this.mode = 0;
            this.number = 0;
        }

        public ShootCmdRequest(byte mode, byte number)
        {
            this.mode = mode;
            this.number = number;
        }
    }
}
