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
    public class BuffDebuffZoneStatus : Message
    {
        public const string RosMessageName = "Roborts/BuffDebuffZoneStatus";

        // buff debuff zone status
        public byte F1_zone_status { get; set; }
        public byte F1_zone_buff_debuff_status { get; set; }
        public byte F2_zone_status { get; set; }
        public byte F2_zone_buff_debuff_status { get; set; }
        public byte F3_zone_status { get; set; }
        public byte F3_zone_buff_debuff_status { get; set; }
        public byte F4_zone_status { get; set; }
        public byte F4_zone_buff_debuff_status { get; set; }
        public byte F5_zone_status { get; set; }
        public byte F5_zone_buff_debuff_status { get; set; }
        public byte F6_zone_status { get; set; }
        public byte F6_zone_buff_debuff_status { get; set; }

        public BuffDebuffZoneStatus()
        {
            this.F1_zone_status = 0;
            this.F1_zone_buff_debuff_status = 0;
            this.F2_zone_status = 0;
            this.F2_zone_buff_debuff_status = 0;
            this.F3_zone_status = 0;
            this.F3_zone_buff_debuff_status = 0;
            this.F4_zone_status = 0;
            this.F4_zone_buff_debuff_status = 0;
            this.F5_zone_status = 0;
            this.F5_zone_buff_debuff_status = 0;
            this.F6_zone_status = 0;
            this.F6_zone_buff_debuff_status = 0;
        }

        public BuffDebuffZoneStatus(byte F1_zone_status, byte F1_zone_buff_debuff_status, byte F2_zone_status, byte F2_zone_buff_debuff_status, byte F3_zone_status, byte F3_zone_buff_debuff_status, byte F4_zone_status, byte F4_zone_buff_debuff_status, byte F5_zone_status, byte F5_zone_buff_debuff_status, byte F6_zone_status, byte F6_zone_buff_debuff_status)
        {
            this.F1_zone_status = F1_zone_status;
            this.F1_zone_buff_debuff_status = F1_zone_buff_debuff_status;
            this.F2_zone_status = F2_zone_status;
            this.F2_zone_buff_debuff_status = F2_zone_buff_debuff_status;
            this.F3_zone_status = F3_zone_status;
            this.F3_zone_buff_debuff_status = F3_zone_buff_debuff_status;
            this.F4_zone_status = F4_zone_status;
            this.F4_zone_buff_debuff_status = F4_zone_buff_debuff_status;
            this.F5_zone_status = F5_zone_status;
            this.F5_zone_buff_debuff_status = F5_zone_buff_debuff_status;
            this.F6_zone_status = F6_zone_status;
            this.F6_zone_buff_debuff_status = F6_zone_buff_debuff_status;
        }
    }
}
