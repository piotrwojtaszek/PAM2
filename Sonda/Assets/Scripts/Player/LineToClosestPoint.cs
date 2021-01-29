using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineToClosestPoint : MonoBehaviour
{
    private Transform closestPoint;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int distance = 100000;
        foreach(Transform obj in GameManager.instance.checkpoints)
        {
            int newDistance = (int)Vector3.Distance(transform.position, obj.position);
            if(newDistance<distance)
            {
                distance = newDistance;
                closestPoint=obj;
            }
        }
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, closestPoint.position);
    }
}
