using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointFollower : MonoBehaviour
{
    Transform m_player;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = m_player.position;
    }
}
