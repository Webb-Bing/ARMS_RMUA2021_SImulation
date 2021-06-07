using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurnSingleCamera : MonoBehaviour
{
    private Vector3 m_camRot;
    private Transform m_camTransform;
    private Transform m_transform;
    public float m_movSpeed = 10;
    public float m_rotateSpeed = 2;

    public float sensitivityHor = 1f;
    private float rotHor;

    private void Start()
    {
        m_camTransform = Camera.main.transform;
        m_transform = GetComponent<Transform>();
        //rotHor = -transform.eulerAngles.x;
    }

    private void Update()
    {
        Control();
    }

    void Control()
    {
        float xm = 0, ym = 0, zm = 0;
        if (Input.GetKey(KeyCode.S))
        {
            zm -= m_movSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            zm += m_movSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xm += m_movSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xm -= m_movSpeed * Time.deltaTime;
        }

        m_transform.Translate(new Vector3(xm, ym, zm), Space.Self);

        float mouseHor = Input.GetAxis("Mouse X");
        rotHor += mouseHor * sensitivityHor;
        transform.localEulerAngles = new Vector3(0, rotHor, 0);
    }
}