using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude < 1)
            Debug.LogWarning("Male BUM");
        else if (collision.relativeVelocity.magnitude >= 1 && collision.relativeVelocity.magnitude <= 4f)
            Debug.LogWarning("Srednie BUM");
        else if (collision.relativeVelocity.magnitude > 4)
            Debug.LogWarning("Duze BUM");
    }
}
