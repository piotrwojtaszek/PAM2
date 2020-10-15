using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    //wyzwanie: systemy spowalniajace obrot zawiodly, opanuj statek
    //wyzwanie: mozesz uzywac tylko jednego typu silnikow manewrowych tzn. np. Q i E, musisz odpowiednio dopasowac sie do figury
    //gdy obracamy kamera przyciski sa wylaczaone
    //usunac stabilise bo jest angular drag wiec 
    //zanim nie opanujemy sondy nie bedziemy w stanie wyhamowac 
    //dac mozliwosc stalego napedu
    private Rigidbody m_rb;
    public float m_verticalTorque = 10f;
    public float m_horizontalTorque = 10f;
    public float m_rotateTorque = 10f;
    public float m_mainEngine = 100f;
    public Action activeEngines;
    public bool m_invertControlls = false;
    float m_invertVariable = 1f;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        if(m_invertControlls)
        {
            m_invertVariable= 1f;
        }
        else
        {
            m_invertVariable = -1f;
        }
        //m_rb.maxAngularVelocity = 20f;

        /*m_rb.angularDrag = 0f;
        m_rb.AddTorque(transform.forward * m_rotateTorque * 8f,ForceMode.Impulse);
        m_rb.AddTorque(transform.up * m_rotateTorque * 12f, ForceMode.Impulse);*/
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        PcInputHandler();

        m_rb.angularVelocity = new Vector3(Mathf.Round(m_rb.angularVelocity.x * 1000) / 1000f, Mathf.Round(m_rb.angularVelocity.y * 1000) / 1000f, Mathf.Round(m_rb.angularVelocity.z * 1000) / 1000f);
        //Debug.Log("x:" + m_rb.angularVelocity.x + "     y:" + m_rb.angularVelocity.y + "    z:" + m_rb.angularVelocity.z + "     RotatationSpeed:" + m_rb.angularVelocity.magnitude + "  velocity:" + m_rb.velocity.magnitude);



        activeEngines?.Invoke();

    }

    private void Stablilise()
    {
        if (m_rb.angularVelocity.magnitude < .07f)
        {
            m_rb.angularVelocity = Vector3.zero;
        }
    }//dodac losowe awarie kamere z przdu

    private void Engine()//osiagniecie max zniszczy statek
    {
        if (m_rb.velocity.magnitude < 5f)
            m_rb.AddForce(transform.forward * m_mainEngine);
        else
            LimitVelocity();
    }

    private void LimitVelocity()
    {
        if (m_rb.velocity.magnitude >= 5f)
            m_rb.velocity = Vector3.ClampMagnitude(m_rb.velocity, 4.9f);
    }

    private void Forward()
    {
        m_rb.AddTorque(transform.right * m_verticalTorque * 1f * m_invertVariable);
    }

    private void Back()
    {
        m_rb.AddTorque(transform.right * m_verticalTorque * -1f * m_invertVariable);
    }

    private void Right()
    {
        m_rb.AddTorque(transform.up * m_horizontalTorque * -1f * m_invertVariable);
    }
    private void Left()
    {
        m_rb.AddTorque(transform.up * m_horizontalTorque * 1f * m_invertVariable);
    }

    private void LRotate()
    {
        m_rb.AddTorque(transform.forward * m_rotateTorque * 1f * m_invertVariable);
    }

    private void RRotate()
    {
        m_rb.AddTorque(transform.forward * m_rotateTorque * -1f * m_invertVariable);
    }

    public void EngineDown()
    {
        activeEngines += Engine;
    }
    public void EngineUp()
    {
        activeEngines -= Engine;
    }

    public void FowardDown()
    {
        Debug.LogWarning("Down");
        activeEngines += Forward;
    }

    public void ForwardUp()
    {
        Debug.LogWarning("UP");
        activeEngines -= Forward;
    }

    public void BackDown()
    {
        activeEngines += Back;
    }

    public void BackUp()
    {
        activeEngines -= Back;
    }

    public void RightDown()
    {
        activeEngines += Right;
    }

    public void RightUp()
    {
        activeEngines -= Right;
    }

    public void LeftDown()
    {
        activeEngines += Left;
    }

    public void LeftUp()
    {
        activeEngines -= Left;
    }

    public void RightRotateDown()
    {
        activeEngines += RRotate;
    }

    public void RightRotateUp()
    {
        activeEngines -= RRotate;
    }

    public void LeftRotateDown()
    {
        activeEngines += LRotate;
    }

    public void LeftRotateUp()
    {
        activeEngines -= LRotate;
    }

    void PcInputHandler()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            FowardDown();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            BackDown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            LeftDown();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RightDown();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LeftRotateDown();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RightRotateDown();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            ForwardUp();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            BackUp();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            LeftUp();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            RightUp();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            LeftRotateUp();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            RightRotateUp();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EngineDown();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            EngineUp();
        }
    }
}
