using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBody : MonoBehaviour
{
    GameObject[] baseShape;
    GameObject[] curShape;
    [Range(0, 1)] public float springRestLength;
    [Range(10, 100)] public float springPower;

    void Start()
    {
        baseShape = GameObject.FindGameObjectsWithTag("Base Shape Part");
        curShape = GameObject.FindGameObjectsWithTag("Blob Body Part");
        springRestLength = 1;
        springPower = 10;
    }

    void Update()
    {
        
    }

    Vector2 GetBarycenter(ref GameObject[] Lpoint)
    {
        float totalX = 0;
        float totalY = 0;
        foreach (GameObject curPoint in Lpoint)
        {
            totalX += curPoint.transform.position.x;
            totalY += curPoint.transform.position.y;
        }

        return new Vector2(totalX / Lpoint.Length, totalY / Lpoint.Length);
    }

    private void FixedUpdate()
    {
        Vector2 curBarycenter = GetBarycenter(ref curShape);

        float curX = GetComponent<Transform>().transform.position.x;
        float curY = GetComponent<Transform>().transform.position.y;
        
        //GameObject.FindGameObjectWithTag("Base Shape").gameObject.transform.position = GetComponent<Transform>().transform.position;

        //GetComponent<Transform>().transform.position = curBarycenter;

        for (int i = 0; i < curShape.Length; i++)
        {
            Vector2 absolute = new Vector2(curX + curShape[i].GetComponent<Rigidbody2D>().transform.rotation.x, curY + curShape[i].GetComponent<Rigidbody2D>().transform.rotation.y);
            //float epe = (float)(0.5 * springPower * Math.Pow(springRestLength, 2));

            Vector2 recalibrate = new Vector2(baseShape[i].transform.position.x - curShape[i].transform.position.x, baseShape[i].transform.position.y - curShape[i].transform.position.y);

            float epe = 1 / springPower;

            //curShape[i].GetComponent<Rigidbody2D>().AddForce(recalibrate/2);
        }
    }
}
