using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlob : MonoBehaviour
{
    public int moveSpeed;
    public int jumpPower;

    public PlayerFeet playerFeet;
    public BlobGrab blobGrab;
    public int force = 10;
    public ForceMode2D forceMode = ForceMode2D.Impulse;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
        jumpPower = 750;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 curVelocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
/*
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.W))
        {
            // Debug.Log(Vector3.Distance(transform.position, blobGrab.jointPositon) + " max " + blobGrab.rangeGrab);
            Vector3 grapPOint = blobGrab.jointPositon;
            if (Vector3.Distance(transform.position, grapPOint) < blobGrab.rangeGrab)
            {
                blobGrab.stopSwing();
                Debug.Log("canon");
                curVelocity.x -= moveSpeed;
                blobGrab.startSwing();
        }*/
        if(Input.GetKey(KeyCode.A))
            curVelocity.x -= moveSpeed;

        if (Input.GetKey(KeyCode.D))
        {
            curVelocity.x += moveSpeed;
        }


        GetComponent<Rigidbody2D>().velocity = curVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && playerFeet.isGrounded == true  )
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * jumpPower);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && blobGrab.isGrab == true)
        {
            blobGrab.stopSwing();
            GetComponent<Rigidbody2D>().AddForce(blobGrab.jointPositon, forceMode + force);  
        }

        if(Input.GetKeyDown(KeyCode.W) &&  blobGrab.isGrab == true)
        {
            Debug.Log(blobGrab.stockAnchorPos);
            blobGrab.stopSwing();
            transform.position += new Vector3(0, 1,0);
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
    }

}