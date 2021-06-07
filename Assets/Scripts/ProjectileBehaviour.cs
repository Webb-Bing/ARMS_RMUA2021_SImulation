using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    
    public class ProjectileBehaviour : MonoBehaviour
    {

        public Collider BaseLink;
        private void Start()
        {
            Debug.Log("created");
            //Physics.IgnoreCollision(this.GetComponent<Collider>(), BaseLink, true);
        }

        // private void OnCollisionEnter(Collision other)
        // {
        //     Debug.Log("hit: " + other.transform.name);
        //     switch(other.transform.tag)
        //     {
        //         case "FrontArmor":
        //             other.transform.gameObject.SendMessage("ProjectileHit", 20);
        //             Debug.Log("hit Front armor");
        //             // Destroy(gameObject);
        //             break;
        //         case "RearArmor":
        //             other.transform.gameObject.SendMessage("ProjectileHit", 60);
        //             Debug.Log("hit Rear armor");
        //             // Destroy(gameObject);
        //             break;
        //         case "RLArmor":
        //             other.transform.gameObject.SendMessage("ProjectileHit", 40);
        //             Debug.Log("hit RLArmo armor");
        //             // Destroy(gameObject);
        //             break;
        //         
        //         case "baseBoard":
        //             break;
        //         
        //         default:
        //             // Destroy(gameObject);
        //             break;
        //     }
        //     
        // }
    }
}