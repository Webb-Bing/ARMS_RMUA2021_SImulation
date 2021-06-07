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
    public class RobotShoot : Message
    {
        public const string RosMessageName = "roborts_msgs/RobotShoot";

        // robot shoot data
        public byte frequency { get; set; }
        public double speed { get; set; }

        public RobotShoot()
        {
            this.frequency = 0;
            this.speed = 0.0;
        }

        public RobotShoot(byte frequency, double speed)
        {
            this.frequency = frequency;
            this.speed = speed;
        }
    }
}
