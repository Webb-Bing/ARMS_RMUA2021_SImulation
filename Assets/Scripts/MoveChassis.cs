using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveChassis : MonoBehaviour
{
    private Vector3 m_camRot;
    private Transform m_transform;//摄像机父物体Transform
    public float m_movSpeed = 10;//移动系数
    public float m_rotateSpeed = 2;//旋转系数

    public float sensitivityHor = 1f; // 水平视角移动的敏感度
    private float rotHor;   //旋转角度

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
        float xm = 0, ym = 0, zm = 0;   // 定义3个值控制移动
        if (Input.GetKey(KeyCode.W))
        {
            zm += m_movSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zm -= m_movSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xm -= m_movSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xm += m_movSpeed * Time.deltaTime;
        }

        m_transform.Translate(new Vector3(xm, ym, zm), Space.Self);


        float mouseHor = Input.GetAxis("Mouse X");  // 获取鼠标左右的移动位置
        rotHor += mouseHor * sensitivityHor;    // 鼠标往上移动，视角往下移，所以要减去它
        transform.localEulerAngles = new Vector3(0, rotHor, 0); // 设置视角的移动值
    }
}