using System;
using System.Collections;
using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityStandardAssets.Utility
{
    public class RobotStatus : MonoBehaviour
    {
        private int INIT_HP = 2000;

        // manually set init position
        public Vector3 INIT_POSITION;
        public Vector3 INIT_ROTATION;
        public Vector3 currentPos;
        public byte robotId;
        public byte level;
        public bool chassis_output;
        public bool gimbal_output;
        public bool shooter_output;
        public bool bonus;
        public int currentHP;
        public int currentHeat;
        public int barrelHeatLimit = 240;
        public int coolingRate = 0;
        public int inBuffNumber = 0;
        public int currentLaunchSpeed;
        public int currentLaunchFrequency;
        public int numberOfProjectileLaunched;
        public int numberOfProjectileRemaining;
        ArrayList powerSupplyStatus = new ArrayList();
        public bool isDead = false;

        public ushort chassis_volt;
        public ushort chassis_current;
        public double chassis_power;
        public ushort chassis_power_buffer;

        public GameObject launcherObj;
        private LaunchProjectile launcherBehavior;
        
        public RobotDamagePublisher RobotDamagePublisher;
        
        private GameObject refereeSystem;
        private RefereeSystemBehavior refereeSystemBehavior;
        
        // robot damage
        const byte ARMOR = 0;
        const byte OFFLINE = 1;
        const byte EXCEED_HEAT = 2;
        const byte FORWARD = 0;
        const byte LEFT = 1;
        const byte BACKWARD = 2;
        const byte RIGHT = 3;
        byte EXCEED_POWER = 3;
        
        
        private void Start()
        {
            currentHP = INIT_HP;
            chassis_output = true;
            gimbal_output = true;
            shooter_output = true;
            bonus = false;
            chassis_volt = 1;
            chassis_current = 1;
            chassis_power = 1;
            chassis_power_buffer = 1;
            // INIT_ROTATION = gameObject.transform.eulerAngles;
            refereeSystem = GameObject.Find("RefereeSystem");

            RobotDamagePublisher = gameObject.GetComponent<RobotDamagePublisher>();
            if (RobotDamagePublisher == null)
            {
                Debug.Log("please attach RobotDamagePublisher to Robot " + gameObject.name);
            }
            if (refereeSystem != null)
            {
                refereeSystemBehavior = refereeSystem.GetComponent<RefereeSystemBehavior>();
            } else
            {
                Debug.LogWarning("Cannot find RefereeSystem");
            }
            
            if (launcherObj != null)
            {
                launcherBehavior = launcherObj.GetComponent<LaunchProjectile>();
                // Debug.Log("Debug: " + launcherBehavior.numBarrelHeat);
            } else
            {
                Debug.LogWarning("please attach gimbal pitch obj to RobotStatus script");
            }
        }

        private void Update()
        {
            HandleDeath();
            HandleInfo();
        }

        // take damage number, if currentHP is <= 0, die!!
        public void TakeDamage(int damageNum, String reason)
        {
            if (isDead) return;
            
            switch (reason)
            {
                case "overheat":
                    RobotDamagePublisher.SendDamageMessage(8, 2);
                    break;
                case "front":
                    RobotDamagePublisher.SendDamageMessage(0, 0);
                    break;
                case "back":
                    RobotDamagePublisher.SendDamageMessage(2, 0);
                    break;
                case "left":
                    RobotDamagePublisher.SendDamageMessage(1, 0);
                    break;
                case "right":
                    RobotDamagePublisher.SendDamageMessage(3, 0);
                    break;
                case "offline":
                    RobotDamagePublisher.SendDamageMessage(8, 1);
                    break;
                case "overpower":
                    RobotDamagePublisher.SendDamageMessage(8, 3);
                    break;
            }

            Debug.Log(damageNum + " damage from " + reason);
            
            currentHP -= damageNum;
            if (currentHP <= 0)
            {
                isDead = true;
                Debug.Log("Robot is dead!");
                currentHP = 0;
            }
        }
        
        // check whether dead, if so, do something.
        private void HandleDeath()
        {
            // if (Input.GetKey(KeyCode.L))
            if (isDead)
            {
                // do something if the bot dead, RendDeath method is defined in RobotDie
                BroadcastMessage("RendDeath", null,SendMessageOptions.DontRequireReceiver);
            }
        }

        private void HandleInfo()
        {
            // update info
            currentHeat = launcherBehavior.numBarrelHeat;
            currentLaunchSpeed = launcherBehavior.launchSpeed;
            numberOfProjectileLaunched = launcherBehavior.numProjectileLaunched;
            numberOfProjectileRemaining = launcherBehavior.numProjectileRemaining;
            currentLaunchFrequency = launcherBehavior.CurrentLaunchFrequency;
            currentPos = gameObject.transform.position;
            coolingRate = launcherBehavior.CoolingRate;
            barrelHeatLimit = launcherBehavior.BarrelHeatLimit1;
        }

        public void InitRobot()
        {
            launcherBehavior.numBarrelHeat = 0;
            launcherBehavior.numProjectileLaunched = 0;
            launcherBehavior.numProjectileRemaining = 10;
            currentHP = INIT_HP;
            
            
            var o = gameObject;
            o.transform.position = INIT_POSITION;
            o.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(INIT_ROTATION.x, INIT_ROTATION.y, INIT_ROTATION.z), 0.05f);

            
            if (isDead)
            {
                // reborn
                BroadcastMessage("RendReborn", gameObject.name, SendMessageOptions.DontRequireReceiver);
                isDead = false;
            }
        }

        public int CurrentHp => currentHP;

        public int CurrentHeat => currentHeat;

        public int CurrentLaunchSpeed => currentLaunchSpeed;

        public int CurrentLaunchFrequency => currentLaunchFrequency;

        public int NumberOfProjectileLaunched => numberOfProjectileLaunched;

        public int NumberOfProjectileRemaining => numberOfProjectileRemaining;

        public Vector3 CurrentPos => currentPos;

        public ArrayList PowerSupplyStatus => powerSupplyStatus;

        public bool IsDead => isDead;

        public int BarrelHeatLimit1 => barrelHeatLimit;

        public int CoolingRate => coolingRate;

        public byte RobotId => robotId;

        public byte Level
        {
            get => level;
            set => level = value;
        }

        public bool ChassisOutput
        {
            get => chassis_output;
            set => chassis_output = value;
        }

        public bool GimbalOutput
        {
            get => gimbal_output;
            set => gimbal_output = value;
        }

        public bool ShooterOutput
        {
            get => shooter_output;
            set => shooter_output = value;
        }

        public int InBuffNumber
        {
            get => inBuffNumber;
            set => inBuffNumber = value;
        }

        public bool Bonus
        {
            get => bonus;
            set => bonus = value;
        }

        public ushort ChassisVolt
        {
            get => chassis_volt;
            set => chassis_volt = value;
        }

        public ushort ChassisCurrent
        {
            get => chassis_current;
            set => chassis_current = value;
        }

        public double ChassisPower
        {
            get => chassis_power;
            set => chassis_power = value;
        }

        public ushort ChassisPowerBuffer
        {
            get => chassis_power_buffer;
            set => chassis_power_buffer = value;
        }
        
        public int InitHp => INIT_HP;
    }
}