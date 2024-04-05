using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int moveSpeed;
    public int slideSpeed;
    public int jumpPower;
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    private Transform wallCheck;

    public PlayerFeet playerFeet;
    public LeftWallJump leftWallJump;
    public RightWallJump rightWallJump;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
        slideSpeed = 5;
        jumpPower = 500;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 curVelocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            curVelocity.x -= moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            curVelocity.x += moveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = curVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && (playerFeet.isGrounded == true))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * jumpPower);
        }

/*        else if (Input.GetKeyDown(KeyCode.Space) &&  leftWallJump.isLeftWall)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(5 += GetComponent<Rigidbody2D>().velocity.x, 2/3) * jumpPower);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && rightWallJump.isRightWall)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-5 - GetComponent<Rigidbody2D>().velocity.x, 2/3) * jumpPower);
        }*/

    }
}