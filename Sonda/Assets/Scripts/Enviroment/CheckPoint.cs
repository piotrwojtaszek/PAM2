using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject prefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UICanvas.instance.CreatePanel(prefab, UICanvas.instance.m_popup);
            Destroy(this.gameObject);
        }
    }
}
