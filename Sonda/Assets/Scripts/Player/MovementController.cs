using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //wyzwanie: systemy spowalniajace obrot zawiodly, opanuj statek
    //wyzwanie: mozesz uzywac tylko jednego typu silnikow manewrowych tzn. np. Q i E, musisz odpowiednio dopasowac sie do figury
    //gdy obracamy kamera przyciski sa wylaczaone
    //usunac stabilise bo jest angular drag wiec 
    Rigidbody m_rb;
    public float m_verticalTorque = 10f;
    public float m_horizontalTorque = 10f;
    public float m_rotateTorque = 10f;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.maxAngularVelocity = 20f;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        m_rb.AddTorque(transform.up * m_horizontalTorque * -direction.x);
        m_rb.AddTorque(transform.right * m_verticalTorque * direction.y);
        if (Input.GetKey(KeyCode.Q))
            m_rb.AddTorque(transform.forward * m_rotateTorque * 1f);
        if (Input.GetKey(KeyCode.E))
            m_rb.AddTorque(transform.forward * m_rotateTorque * -1f);
        m_rb.angularVelocity = new Vector3(Mathf.Round(m_rb.angularVelocity.x * 1000) / 1000f, Mathf.Round(m_rb.angularVelocity.y * 1000) / 1000f, Mathf.Round(m_rb.angularVelocity.z * 1000) / 1000f);
        Debug.Log("x:" + m_rb.angularVelocity.x + "     y:" + m_rb.angularVelocity.y + "    z:" + m_rb.angularVelocity.z + "     RotatationSpeed:" + m_rb.angularVelocity.magnitude + "  velocity:" + m_rb.velocity.magnitude);
        if (Input.GetKey(KeyCode.Space))
        {
            Stablilise();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {

            Engine();
            //LimitVelocity();
        }

    }

    private void LateUpdate()
    {
        
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
            m_rb.AddForce(transform.forward * m_verticalTorque * 5f);
        else
            LimitVelocity();
    }

    private void LimitVelocity()
    {
        if (m_rb.velocity.magnitude >= 5f)
            m_rb.velocity = Vector3.ClampMagnitude(m_rb.velocity, 4.9f);
    }

    public void Forward()
    {
        m_rb.AddTorque(transform.right * m_verticalTorque * 1f);
    }

    public void Back()
    {
        m_rb.AddTorque(transform.right * m_verticalTorque * -1f);
    }

    public void Right()
    {
        m_rb.AddTorque(transform.up * m_horizontalTorque * -1f);
    }
    public void Left()
    {
        m_rb.AddTorque(transform.up * m_horizontalTorque * 1f);
    }

    public void LRotate()
    {
        m_rb.AddTorque(transform.forward * m_rotateTorque * 1f);
    }

    public void RRotate()
    {
        m_rb.AddTorque(transform.forward * m_rotateTorque * -1f);
    }

    public void StabliliseBtn()
    {
            Stablilise(); 
    }

    public void EngineBtn()
    {
        Engine();
    }
}
