using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [Range(0,10)] public int moveSpeed;
    [Range(500, 800)] public int jumpPower;

    public GameObject blobShape;
    public PlayerFeet playerFeet;



    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
        jumpPower = 750;
    }

    // Update is called once per frame
    void Update()
    {
        blobShape.transform.position = this.transform.position;

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

        if (Input.GetKeyDown(KeyCode.Space) && playerFeet.isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * jumpPower);
        }
    }
}
