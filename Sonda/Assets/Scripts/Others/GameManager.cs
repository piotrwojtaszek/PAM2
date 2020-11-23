using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int maxPoints = 0;
    public int points = 0;


    private void Awake()
    {
        instance = this;
        points = 0;
    }
}
