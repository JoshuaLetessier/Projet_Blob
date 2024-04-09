using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeUpgrade : MonoBehaviour
{
    public bool isSlime;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slime")
        {
            isSlime = true;
        }
    }
}
