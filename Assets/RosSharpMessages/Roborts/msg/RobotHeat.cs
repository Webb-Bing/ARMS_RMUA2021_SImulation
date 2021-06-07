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
    public class RobotHeat : Message
    {
        public const string RosMessageName = "roborts_msgs/RobotHeat";

        // robot power and heat data
        public ushort chassis_volt { get; set; }
        public ushort chassis_current { get; set; }
        public double chassis_power { get; set; }
        public ushort chassis_power_buffer { get; set; }
        public ushort shooter_heat { get; set; }

        public RobotHeat()
        {
            this.chassis_volt = 0;
            this.chassis_current = 0;
            this.chassis_power = 0.0;
            this.chassis_power_buffer = 0;
            this.shooter_heat = 0;
        }

        public RobotHeat(ushort chassis_volt, ushort chassis_current, double chassis_power, ushort chassis_power_buffer, ushort shooter_heat)
        {
            this.chassis_volt = chassis_volt;
            this.chassis_current = chassis_current;
            this.chassis_power = chassis_power;
            this.chassis_power_buffer = chassis_power_buffer;
            this.shooter_heat = shooter_heat;
        }
    }
}
