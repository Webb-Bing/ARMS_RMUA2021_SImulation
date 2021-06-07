using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using Component = UnityEngine.Component;

public class LaunchProjectile : MonoBehaviour
{
    int Speed = 250;
    int ProjectileRemaining = 10;
    int ProjectileLaunched = 0;
    int BarrelHeat = 0;
    int BarrelHeatLimit = 240;
    int coolingRate = 0; 
    int currentLaunchFrequency;
    
    public Rigidbody Projectile;
    public Transform LaunchPoint;
    public GameObject robotObj;
    private RobotStatus robotStatus;

    // Start is called before the first frame update
    void Start()
    {
        // gets robot obj at the start
        
        robotObj = GetRootObject(this.transform).gameObject;
        if (robotObj != null)
        {
            robotStatus = robotObj.GetComponent<RobotStatus>();
        }
        else
        {
            Debug.LogWarning("Can't find Robot Obj from Launcher script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // every call is 0.1 sec
        //Debug.Log("Hot: " + BarrelHeat + " speed" + Speed);
        
        if ((Input.GetKey(KeyCode.Q)) && (ProjectileRemaining > 0))
        {
            
            ProjectileRemaining--;
            ProjectileLaunched++;
            
            BarrelHeat += Speed / 10;
            HandleSpeedDamage();

            Rigidbody clone;

            clone = (Rigidbody)Instantiate(Projectile, LaunchPoint.position, LaunchPoint.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * Speed);
            //Debug.Log("已发射");


            Ray myRay = new Ray(LaunchPoint.transform.position, LaunchPoint.transform.forward);
            //Debug.DrawRay(myRay.origin, myRay.direction, UnityEngine.Color.red);
            RaycastHit hit;
            if (Physics.Raycast(myRay, out hit, 25000))
            {
                //Debug.Log("检测到物体");
                Debug.Log("Ray Hit" + hit.collider.gameObject.name);
                HandleHitArmor(hit.collider.gameObject);
                
                Debug.Log("LaunchPoint.transform.position, LaunchPoint.transform.forward");
                //print(hit.point);
                //print(hit.transform.position);
                print(hit.collider.gameObject);
            }
            
            Destroy(clone.gameObject, 3);
            Destroy(clone, 3);
        }
        
        HandleHeatDamage();
        HandleCoolingHeat();
    }

    private void HandleHitArmor(GameObject armorObj)
    {
        if (Speed < 120) return;
        
        switch(armorObj.tag)
        {
            case "FrontArmor":
                armorObj.SendMessage("ProjectileHit", 20);
                Debug.Log("hit Front armor");
                // Destroy(gameObject);
                break;
            case "RearArmor":
                armorObj.SendMessage("ProjectileHit", 60);
                Debug.Log("hit Rear armor");
                // Destroy(gameObject);
                break;
            case "RLArmor":
                armorObj.SendMessage("ProjectileHit", 40);
                Debug.Log("hit RLArmo armor");
                // Destroy(gameObject);
                break;

            default:
                // Destroy(gameObject);
                break;
        }
    }

    private void HandleCoolingHeat()
    {
        if (BarrelHeat > 0)
        {
            if (robotStatus.currentHP < 400)
            {
                // fast cool down
                BarrelHeat -= 24;
                coolingRate = 240;
            }
            else
            {
                // normal cool down
                BarrelHeat -= 12;
                coolingRate = 120;
            }
        }
        else
        {
            BarrelHeat = 0;
            coolingRate = 0;
        }
    }

    private void HandleHeatDamage()
    {
        if (BarrelHeat > 240 && BarrelHeat < 360)
        {
            // robotObj.SendMessage("TakeDamage", (BarrelHeat - 240) * 4);
            robotStatus.TakeDamage((BarrelHeat - 240) * 4, "overheat");
            //Debug.Log("hot damage!" + (BarrelHeat - 240) * 4);
        } else if (BarrelHeat >= 360)
        {
            // robotObj.SendMessage("TakeDamage", (BarrelHeat - 360) * 40);
            robotStatus.TakeDamage((BarrelHeat - 360) * 40, "overheat");
            //Debug.Log("hot damage!" + (BarrelHeat - 240) * 4);
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

    private void HandleSpeedDamage()
    {
        if (Speed > 250 && Speed < 300)
        {
            // robotObj.SendMessage("TakeDamage", 200);
            robotStatus.TakeDamage(200, "over speed");
            //Debug.Log("Speed damage!" + 200);
            
        } else if (Speed >= 300 && Speed < 350)
        {
            // robotObj.SendMessage("TakeDamage", 1000);
            robotStatus.TakeDamage(1000, "over speed");
            //Debug.Log("Speed damage!" + 1000);
            
        } else if (Speed >= 350)
        {
            // robotObj.SendMessage("TakeDamage", 2000);
            robotStatus.TakeDamage(2000, "over speed");
            //Debug.Log("Speed damage!" + 2000);
        }
    }

    public int launchSpeed => Speed;

    public int CurrentLaunchFrequency => currentLaunchFrequency;

    public int numProjectileRemaining
    {
        get => ProjectileRemaining;
        set => ProjectileRemaining = value;
    }

    public int numProjectileLaunched
    {
        get => ProjectileLaunched;
        set => ProjectileLaunched = value;
    }

    public int numBarrelHeat
    {
        get => BarrelHeat;
        set => BarrelHeat = value;
    }

    public int CoolingRate => coolingRate;

    public int BarrelHeatLimit1 => BarrelHeatLimit;
}