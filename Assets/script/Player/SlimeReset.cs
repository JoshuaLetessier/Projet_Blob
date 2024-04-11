using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeReset : MonoBehaviour
{
    public bool isReset;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Reset")
        {
            isReset = true;
        }
    }
}
