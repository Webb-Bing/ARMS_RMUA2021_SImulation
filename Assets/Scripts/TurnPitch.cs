using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurnPitch : MonoBehaviour
{
    private Vector3 m_camRot;
    private Transform m_transform;
    public float m_movSpeed = 10;
    public float m_rotateSpeed = 2;

    public float sensitivityHor = 1f;
    private float upVer;

    private void Start()
    {
        m_transform = GetComponent<Transform>();
        //rotHor = -transform.eulerAngles.x;
    }

    private void Update()
    {
        Control();
    }

    void Control()
    {
        float mouseHor = Input.GetAxis("Mouse Y");
        upVer -= mouseHor * sensitivityHor;
        if (upVer > 20 )
        {
            upVer = 20;
        }
        else if (upVer < -20)
        {
            upVer = -20;
        }
        transform.localEulerAngles = new Vector3(upVer, 0, 0);
    }
}