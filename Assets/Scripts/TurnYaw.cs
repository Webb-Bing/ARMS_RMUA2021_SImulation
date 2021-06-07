using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurnYaw : MonoBehaviour
{
    private Vector3 m_camRot;
    private Transform m_transform;
    public float m_movSpeed = 10;
    public float m_rotateSpeed = 2;

    public float sensitivityHor = 1f;
    private float rotHor;

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
        float mouseHor = Input.GetAxis("Mouse X");
        rotHor += mouseHor * sensitivityHor;
        if (rotHor > 90)
        {
            rotHor = 90;
        }
        else if (rotHor < -90)
        {
            rotHor = -90;
        }
        transform.localEulerAngles = new Vector3(0, rotHor, 0);
    }
}