using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallJump : MonoBehaviour
{
    public bool isRightWall;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isRightWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isRightWall = false;
        }
    }
}