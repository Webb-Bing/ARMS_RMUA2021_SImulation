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
    public class GimbalAngle : Message
    {
        public const string RosMessageName = "roborts_msgs/GimbalAngle";

        // gimbal feedback angle data
        public bool yaw_mode { get; set; }
        public bool pitch_mode { get; set; }
        public double yaw_angle { get; set; }
        public double pitch_angle { get; set; }

        public GimbalAngle()
        {
            this.yaw_mode = false;
            this.pitch_mode = false;
            this.yaw_angle = 0.0;
            this.pitch_angle = 0.0;
        }

        public GimbalAngle(bool yaw_mode, bool pitch_mode, double yaw_angle, double pitch_angle)
        {
            this.yaw_mode = yaw_mode;
            this.pitch_mode = pitch_mode;
            this.yaw_angle = yaw_angle;
            this.pitch_angle = pitch_angle;
        }
    }
}
