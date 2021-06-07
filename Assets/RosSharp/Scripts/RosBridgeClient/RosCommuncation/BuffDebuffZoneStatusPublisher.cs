// Author: Wennong Cai

using System;
using UnityEngine;

using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace RosSharp.RosBridgeClient
{
    public class BuffDebuffZoneStatusPublisher : UnityPublisher<MessageTypes.Roborts.BuffDebuffZoneStatus>
    {
        private MessageTypes.Roborts.BuffDebuffZoneStatus status;

        const int PUBLISH_FREQUENCY = 10;
        const int REFRESH_FREQUENCY = 600;
        int publish_counter = 0;
        int refresh_counter = 0;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            // DeltaTime = 0.1s
            // Publish every 10 times Update()
            // Refresh buff-debuff zones every 600 times Update()
            UpdateMessage();
            publish_counter += 1;
            refresh_counter += 1;
        }
        
        private void InitializeMessage()
        {
            status = new MessageTypes.Roborts.BuffDebuffZoneStatus();
            refresh();
        }

        private void UpdateMessage()
        {
            if (refresh_counter >= REFRESH_FREQUENCY) {
                refresh();
                refresh_counter -= REFRESH_FREQUENCY;
            }

            if (publish_counter >= PUBLISH_FREQUENCY) {
                Publish(status);
                publish_counter -= PUBLISH_FREQUENCY;
            }
        }

        private readonly System.Random random = new System.Random();
        private int chooseRandomInt(int[] possibleOutput)
        {
            int size = possibleOutput.Length;
            return possibleOutput[random.Next(size)];
        }

        /*
            1 is Red Restoration Zone
            2 is Red Projectile Supplier Zone
            3 is Blue Restoration Zone
            4 is Blue Projectile Supplier Zone
            5 is No Shooting Zone
            6 is No Moving Zone
        */
        private int getPair(int input)
        {
            if (input == 1) return 3;   // 1 - 3
            if (input == 2) return 4;   // 2 - 4
            if (input == 3) return 1;
            if (input == 4) return 2;
            if (input == 5) return 6;   // 5 - 6
            if (input == 6) return 5;
	
			return -1;
        }

        private void removeElementAtIndex(ref int[] arr, int idx)
        {
            for (int i = idx; i < arr.Length - 1; i++) {
                arr[i] = arr[i+1];
            }
            Array.Resize(ref arr, arr.Length - 1);
        }

        private void refresh()
        {
            // Randomly distribute each zone
            int[] possibleStatus = {1,2,3,4,5,6};
            int F1 = chooseRandomInt(possibleStatus);
            int F6 = getPair(F1);
            removeElementAtIndex(ref possibleStatus, Array.IndexOf(possibleStatus, F1));
            removeElementAtIndex(ref possibleStatus, Array.IndexOf(possibleStatus, F6));
            int F2 = chooseRandomInt(possibleStatus);
            int F5 = getPair(F2);
            removeElementAtIndex(ref possibleStatus, Array.IndexOf(possibleStatus, F2));
            removeElementAtIndex(ref possibleStatus, Array.IndexOf(possibleStatus, F5));
            int F3 = chooseRandomInt(possibleStatus);
            int F4 = getPair(F3);

            status.F1_zone_buff_debuff_status = Convert.ToByte(F1);
            status.F2_zone_buff_debuff_status = Convert.ToByte(F2);
            status.F3_zone_buff_debuff_status = Convert.ToByte(F3);
            status.F4_zone_buff_debuff_status = Convert.ToByte(F4);
            status.F5_zone_buff_debuff_status = Convert.ToByte(F5);
            status.F6_zone_buff_debuff_status = Convert.ToByte(F6);

            print("BuffDebuffZone distribution: F1={"+F1+"}, F2={"+F2+"}, F3={"+F3+"}, F4={"+F4+"}, F5={"+F5+"}, F6={"+F6+"}");

            // Change all zones to Active
            status.F1_zone_status = Convert.ToByte(1);
            status.F2_zone_status = Convert.ToByte(1);
            status.F3_zone_status = Convert.ToByte(1);
            status.F4_zone_status = Convert.ToByte(1);
            status.F5_zone_status = Convert.ToByte(1);
            status.F6_zone_status = Convert.ToByte(1);
        }
    }
}
