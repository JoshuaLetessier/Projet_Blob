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

    public int force = 10;
    public ForceMode2D forceMode = ForceMode2D.Impulse;

    public GameObject blobShape;
    public PlayerFeet playerFeet;
    public LeftWallJump leftWallJump;
    public RightWallJump rightWallJump;
    public SlimeUpgrade slimeUpgrade;
    public BlobGrab blobGrab;

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

        //basic mouve
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
                //rb.AddForce(new Vector2(jumpPower,jumpPower * 1 / 2));
                rb.AddForce(Vector2.left * jumpPower * 1 / 2);
            }
            else if (rightWallJump.isRightWall && !playerFeet.isGrounded)
            {
                rb.AddForce(Vector2.right * jumpPower * 1 / 2);
                //rb.AddForce(new Vector2(-jumpPower, jumpPower * 1/2));
            }
            else if (blobGrab.isGrab == true)
            {
                blobGrab.stopSwing();
                GetComponent<Rigidbody2D>().AddForce(blobGrab.jointPositon, forceMode + force);
            }
        }
       

        if (Input.GetKeyDown(KeyCode.W) && blobGrab.isGrab == true)
        {
            Debug.Log(blobGrab.stockAnchorPos);
            blobGrab.stopSwing();
            transform.position += new Vector3(0, 1, 0);
            blobGrab.startSwing();

            Debug.Log(blobGrab.joint.connectedAnchor);
        }
        //blobGrab.joint.connectedAnchor.Set(blobGrab.stockAnchorPos.x, blobGrab.stockAnchorPos.y);
        if (Input.GetKeyDown(KeyCode.S) && blobGrab.isGrab == true)
        {


            blobGrab.stopSwing();
            transform.position -= new Vector3(0, 1, 0);

            blobGrab.startSwing();
            blobGrab.joint.connectedAnchor = blobGrab.stockAnchorPos;
            Debug.Log(blobGrab.joint.connectedAnchor);
        }


        bool isWallSliding = (leftWallJump.isLeftWall || rightWallJump.isRightWall) && !playerFeet.isGrounded;
        if (isWallSliding)
        {
            //disableA = false;
            //disableD = false;
            rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
        }

        if (slimeUpgrade)
        {
            rb.transform.localScale = new Vector2(2, 2);
        }
    }


}