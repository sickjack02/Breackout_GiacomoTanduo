using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDistructor : MonoBehaviour
{
    public float waitTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
    }
}
