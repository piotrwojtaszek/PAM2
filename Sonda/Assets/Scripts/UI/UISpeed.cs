using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpeed : MonoBehaviour
{
    public Image image;
    public Rigidbody rb;
    private void Update()
    {
        image.fillAmount = rb.velocity.magnitude / 5.5f;
    }
}
