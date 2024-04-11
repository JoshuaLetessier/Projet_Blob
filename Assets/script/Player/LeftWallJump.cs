using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWallJump : MonoBehaviour
{
    public bool isLeftWall;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isLeftWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isLeftWall = false;
        }
    }
}