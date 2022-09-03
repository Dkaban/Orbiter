using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public float G = 3000f;
    public static SolarSystem Instance;
    public List<GameObject> starList;

    private void Awake()
    {
        Instance = this;
    }
}
