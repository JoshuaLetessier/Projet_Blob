using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "usable object")
        {
           // collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

}
