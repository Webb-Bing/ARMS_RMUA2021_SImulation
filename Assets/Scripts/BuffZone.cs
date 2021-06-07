using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;


public class BuffZone : MonoBehaviour
{
    public GameObject robotObj;
    private RobotStatus robotStatus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Chassis")
        {
            Debug.Log(gameObject.tag + "开始接触" + "Tag-" + other.tag + ", Name-" + other.name);
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Chassis")
        {
            Debug.Log(gameObject.tag + "停止接触" + "Tag-" + other.tag + ", Name-" + other.name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Chassis")
        {
            Debug.Log(gameObject.tag + "正在接触" + "Tag-" + other.tag + ", Name-" + other.name);
        }
    }
    
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
}