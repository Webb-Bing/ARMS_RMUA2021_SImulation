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
    public class BonusStatus : Message
    {
        public const string RosMessageName = "roborts_msgs/BonusStatus";

        // bonus zone status
        public const byte UNOCCUPIED = 0;
        public const byte BEING_OCCUPIED = 1;
        public const byte OCCUPIED = 2;
        public byte red_bonus { get; set; }
        public byte blue_bonus { get; set; }

        public BonusStatus()
        {
            this.red_bonus = 0;
            this.blue_bonus = 0;
        }

        public BonusStatus(byte red_bonus, byte blue_bonus)
        {
            this.red_bonus = red_bonus;
            this.blue_bonus = blue_bonus;
        }
    }
}
