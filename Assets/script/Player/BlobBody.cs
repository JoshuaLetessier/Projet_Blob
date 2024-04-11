using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBody : MonoBehaviour
{
    List<Vector3> baseShape = new List<Vector3>();
    GameObject[] curShape;

    void Start()
    {
        curShape = GameObject.FindGameObjectsWithTag("Blob Body Part");
        foreach (GameObject point in curShape)
        {
            Vector3 pos = new (point.GetComponent<Transform>().position.x, point.GetComponent<Transform>().position.y);
            baseShape.Add(pos);
        }
    }

    void Update()
    {
        
    }
}
