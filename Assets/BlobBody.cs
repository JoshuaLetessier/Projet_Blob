using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBody : MonoBehaviour
{
    GameObject[] baseShape;
    GameObject[] curShape;
    [Range(0, 1)] public float springRestLength;
    [Range(1, 10)] public float springPower;

    void Start()
    {
        baseShape = GameObject.FindGameObjectsWithTag("Blob Body Part");
        curShape = baseShape;
        springRestLength = 1;
        springPower = 0;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < curShape.Length; i++)
        {
            float epe = (float)(0.5 * springPower * Math.Pow(springRestLength, 2));

            Vector2 recalibrate = new Vector2(baseShape[i].transform.position.x - curShape[i].transform.position.x, baseShape[i].transform.position.y - curShape[i].transform.position.y);

            GetComponent<Rigidbody2D>().AddForce(recalibrate * epe);
        }
    }
}
