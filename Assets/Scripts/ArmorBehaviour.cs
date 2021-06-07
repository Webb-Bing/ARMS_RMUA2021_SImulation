using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class ArmorBehaviour : MonoBehaviour
    {
        public GameObject robotObj;
        public String armorId = "default";
        public bool isLeftArmor;
        private RobotStatus robotStatus;
        private void Start()
        {
            robotObj = GetRootObject(this.transform).gameObject;
            if (robotObj != null)
            {
                robotStatus = robotObj.GetComponent<RobotStatus>();
            }
            else
            {
                Debug.LogWarning("Can't find Robot Obj from Armor script");
            }
            
        }
        
        private Transform GetRootObject(Transform childObject)    
        { 
            if(childObject.parent == null)    
            {    
                return childObject;    
            }    
            else    
            {    
                return GetRootObject(childObject.parent);    
            }    
        }

        public void ProjectileHit(int damageNum)
        {
            // robotObj.SendMessage("TakeDamage", damageNum);

            switch (damageNum)
            {
                case 60:
                    robotStatus.TakeDamage(damageNum, "back");
                    break;
                case 20:
                    robotStatus.TakeDamage(damageNum, "front");
                    break;
                case 40 when isLeftArmor:
                    robotStatus.TakeDamage(damageNum, "left");
                    break;
                case 40:
                    robotStatus.TakeDamage(damageNum, "right");
                    break;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            
            // ignore bullet
            // bullet should have a tag called 'projectile'
            if (other.transform.CompareTag("projectile")) return;
            
            switch(gameObject.tag)
            {
                case "FrontArmor":
                    robotStatus.TakeDamage(10, "front");
                    // Destroy(gameObject);
                    break;
                case "RearArmor":
                    robotStatus.TakeDamage(10, "back");
                    // Destroy(gameObject);
                    break;
                case "RLArmor":
                    robotStatus.TakeDamage(10, isLeftArmor ? "left" : "right");
                    // Destroy(gameObject);
                    break;
                default:
                    // Destroy(gameObject);
                    break;
            }
        }
    }
    
}