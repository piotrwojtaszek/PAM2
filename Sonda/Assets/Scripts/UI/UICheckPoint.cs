using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICheckPoint : MonoBehaviour
{
    public TextMeshProUGUI checkPointNumber;

    public void SetNumber(string text)
    {
        checkPointNumber.text = text;
    }
}
