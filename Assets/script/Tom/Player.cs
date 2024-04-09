using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int slideSpeed;
    private float wallSlidingSpeed = 2f;

    private bool disableA = true;
    private bool disableD = true;

    [Range(0, 10)] public int moveSpeed;
    [Range(500, 800)] public int jumpPower;

    public GameObject blobShape;
    public PlayerFeet playerFeet;
    public LeftWallJump leftWallJump;
    public RightWallJump rightWallJump;
    public SlimeUpgrade slimeUpgrade;
    public SlimeReset slimeReset;

    private Rigidbody2D rb;

    void Start()
    {
        moveSpeed = 10;
        slideSpeed = 5;
        jumpPower = 500;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 curVelocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKey(KeyCode.A) && disableA)
        {
            curVelocity.x -= moveSpeed;
        }
        if (Input.GetKey(KeyCode.D) && disableD)
        {
            curVelocity.x += moveSpeed;
        }

        rb.velocity = curVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && playerFeet.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (leftWallJump.isLeftWall && !playerFeet.isGrounded)
            {
                rb.AddForce(new Vector2(jumpPower, jumpPower * 1 / 2));
            }
            else if (rightWallJump.isRightWall && !playerFeet.isGrounded)
            {
                rb.AddForce(new Vector2(-jumpPower, jumpPower * 1/2));
            }
        }

        bool isWallSliding = (leftWallJump.isLeftWall || rightWallJump.isRightWall) && !playerFeet.isGrounded;
        if (isWallSliding)
        {
            //disableA = false;
            //disableD = false;
            rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
        }

        if (slimeUpgrade.isSlime)
        {
            rb.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (slimeReset.isReset)
        {
            rb.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }



}