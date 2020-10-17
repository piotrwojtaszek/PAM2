using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineFreeLook m_freeLook;
    [SerializeField]
    private CinemachineVirtualCamera m_followCamera;
    private Vector2 firstpoint;
    private float xAngTemp;
    private float yAngTemp;
    private Vector2 secondpoint;
    private float xAngle;
    private float yAngle;
    public Vector2 m_Speed;
    public bool m_moving = false;
    private float m_idleTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        m_freeLook = GetComponent<CinemachineFreeLook>();
        //m_freeLook.m_YAxis.Value = 0.8f;
        //m_freeLook.m_XAxis.Value = 0.8f;
        xAngle = 0.0f;
        yAngle = m_freeLook.m_YAxis.Value;
        m_freeLook.Priority = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && m_moving)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;
                //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                xAngle = xAngTemp + (secondpoint.x - firstpoint.x) / Screen.width * m_Speed.x;
                yAngle = yAngTemp - (secondpoint.y - firstpoint.y) / Screen.height * m_Speed.y;
                //Rotate camera
                //Debug.Log(yAngle + "  x:" + xAngle);
                m_freeLook.m_YAxis.Value = yAngle;
                m_freeLook.m_XAxis.Value = xAngle;
                xAngTemp -= xAngle;


            }
            else
            {
                //m_freeLook.m_XAxis.Value = 0f;

                //m_idleTime += Time.deltaTime;
            }
        }
        if (m_moving)
        {
            m_freeLook.Priority = 100;
            m_followCamera.Priority = 1;
        }
        else
        {
            m_freeLook.Priority = 1;
            m_followCamera.Priority = 100;
        }

    }

    public void CameraMode()
    {
        m_moving = !m_moving;
    }
}
