using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody m_rb;
    public float m_torque = 10f;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.maxAngularVelocity = 20f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        m_rb.AddTorque(transform.up * m_torque * -direction.x);
        m_rb.AddTorque(transform.right * m_torque * direction.y);
        if(Input.GetKey(KeyCode.Q))
            m_rb.AddTorque(transform.forward * m_torque * 1f);
        if (Input.GetKey(KeyCode.E))
            m_rb.AddTorque(transform.forward * m_torque * -1f);
        m_rb.angularVelocity =new Vector3( Mathf.Round(m_rb.angularVelocity.x *1000)/1000f,Mathf.Round(m_rb.angularVelocity.y * 1000)/1000f,Mathf.Round(m_rb.angularVelocity.z * 1000)/1000f);
        Debug.Log("x:" + m_rb.angularVelocity.x + "     y:" + m_rb.angularVelocity.y + "    z:" + m_rb.angularVelocity.z);
    }
}
