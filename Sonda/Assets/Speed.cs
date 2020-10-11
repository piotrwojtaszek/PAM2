﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public Rigidbody m_rb;
    TextMeshProUGUI m_text;
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = m_rb.velocity.magnitude.ToString("0.00");
    }
}
