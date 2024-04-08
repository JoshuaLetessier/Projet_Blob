using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float Kstiffness;
    public float LrestLength;
    public float KdampingFactor;

    // Start is called before the first frame update
    void Start()
    {
        Kstiffness = 20f;
        Vector3 AB = pointB.transform.position - pointA.transform.position;
        LrestLength = Mathf.Abs(Mathf.Pow(AB.x, 2) + Mathf.Pow(AB.y, 2)); ;
        KdampingFactor = 2f;
        //GetComponent<Transform>().transform.position = pointA.transform.position;
        //GetComponent<Transform>().transform.localScale = pointB.transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 AB = pointB.transform.position - pointA.transform.position;
        Vector3 BA = pointA.transform.position - pointB.transform.position;
        float curLength = Mathf.Abs(Mathf.Pow(AB.x, 2) + Mathf.Pow(AB.y, 2));
        float Fs = Kstiffness * (curLength - LrestLength);
        Vector3 v = (pointB.GetComponent<Rigidbody2D>().velocity - pointA.GetComponent<Rigidbody2D>().velocity);
        float Fd = (AB.normalized.x * v.x + AB.normalized.y * v.y + AB.normalized.z * v.z) * KdampingFactor;

        float Ft = Fs + Fd;

        Vector3 Fa = Ft * AB.normalized;
        Vector3 Fb = Ft * BA.normalized;

        pointA.GetComponent<Rigidbody2D>().AddForce(Fa);
        pointB.GetComponent<Rigidbody2D>().AddForce(Fb);
    }
}
