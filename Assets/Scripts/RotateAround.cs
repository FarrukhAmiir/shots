using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    float timecounter = 0;
    public float speed;
    public float xaxis, yaxis,height;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timecounter += Time.deltaTime*speed;
        float x = Mathf.Cos(timecounter);
        float y = Mathf.Sin(timecounter)+height;
        float z = 0;
        transform.position = new Vector3(x * xaxis, y * yaxis, 0);
    }
}