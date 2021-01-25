using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    float collTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        collTime += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collTime < 1f)
            return;
        float relativeVelocity = collision.relativeVelocity.magnitude;
        if (collision.collider.transform.localScale.magnitude <= 10f)
        {
            relativeVelocity = 2f;
        }

        if (relativeVelocity < 2f && relativeVelocity > 1f)
        {
            Debug.LogWarning("Male BUM");
            PlayerController.instance.TakeDamage(10f);
        }
        else if (relativeVelocity >= 2f && relativeVelocity <= 4f)
        {
            PlayerController.instance.TakeDamage(50f);
            Debug.LogWarning("Srednie BUM");
        }

        else if (relativeVelocity > 4f)
        {
            PlayerController.instance.TakeDamage(100f);
            Debug.LogWarning("Duze BUM");
        }
        collTime = 0f;
    }
}
