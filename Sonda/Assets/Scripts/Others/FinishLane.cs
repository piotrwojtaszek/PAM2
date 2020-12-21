using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLane : MonoBehaviour
{
    Renderer render;
    BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();

        render.enabled = false;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.points==GameManager.instance.maxPoints)
        {
            render.enabled = true;
            collider.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Complete();
        }
    }
}
