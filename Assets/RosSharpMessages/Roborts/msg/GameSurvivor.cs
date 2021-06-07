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
    public class GameSurvivor : Message
    {
        public const string RosMessageName = "roborts_msgs/GameSurvivor";

        // robot survival
        public bool red3 { get; set; }
        public bool red4 { get; set; }
        public bool blue3 { get; set; }
        public bool blue4 { get; set; }

        public GameSurvivor()
        {
            this.red3 = false;
            this.red4 = false;
            this.blue3 = false;
            this.blue4 = false;
        }

        public GameSurvivor(bool red3, bool red4, bool blue3, bool blue4)
        {
            this.red3 = red3;
            this.red4 = red4;
            this.blue3 = blue3;
            this.blue4 = blue4;
        }
    }
}
