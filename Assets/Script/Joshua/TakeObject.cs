using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{

    public GameObject center;
    public  test _test;

    public bool isTake;

    private void Start()
    {
        isTake = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "usable object" && isTake == false)
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
         
            collision.gameObject.transform.SetParent(gameObject.transform);
            collision.gameObject.transform.position = center.transform.position;
            _test.jumpPower = _test.jumpPower -50;

            isTake = true;
        }
    }
}
