using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public GameObject m_particlePrefab;
    public MovementController m_movement;
    public Transform m_mainEngine;

    private bool m_corutine = false;
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (m_movement.m_mainEngineOn && !m_corutine)
        {
            StartCoroutine(IniciateParticles());
        }
    }

    private IEnumerator IniciateParticles()
    {
        m_corutine = true;
        while (m_movement.m_mainEngineOn)
        {
            Debug.Log("Partcles");
            Instantiate(m_particlePrefab,m_mainEngine);


            yield return new WaitForSeconds(0.2f);
        }
        m_corutine = false;
        yield return null;
    }
}
