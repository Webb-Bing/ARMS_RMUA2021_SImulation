using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDie : MonoBehaviour
{
    public Material meshRender = null;
    public Renderer rend;
    public Texture texture;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            RendDeath();
        }
    }

    private void RendDeath()
    {
        meshRender = Resources.Load("RobotDie") as Material;
        if (meshRender == null)
        {
            Debug.Log("没找到RobotDie材质球鸭");
            return;
        }
        rend = GetComponent<Renderer>();
           
        rend.sharedMaterial = meshRender;
         
        Debug.Log(GetComponent<Renderer>().material);
        Debug.Log(GetComponent<MeshRenderer>().material.mainTexture);
    }

    private void RendReborn(String botName)
    {
        String resourceName;
        switch (botName)
        {
            case "B1":
                resourceName = "ChassisB0";
                break;
            case "B2":
                resourceName = "ChassisB1";
                break;
            case "R1":
                resourceName = "ChassisR0";
                break;
            case "R2":
                resourceName = "ChassisR1";
                break;
            default:
                resourceName = "error";
                Debug.Log("Bot Name Error");
                break;
        }
        
        meshRender = Resources.Load(resourceName) as Material;
        if (meshRender == null)
        {
            Debug.Log("没找到" + resourceName + "材质球鸭");
            return;
        }
        rend = GetComponent<Renderer>();
           
        rend.sharedMaterial = meshRender;
    }
}