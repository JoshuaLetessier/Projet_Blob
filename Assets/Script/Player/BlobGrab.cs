using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class BlobGrab : MonoBehaviour
{

    public new Transform transform;
    public HingeJoint2D joint;
    public Rigidbody2D rb;

    public PlayerFeet playerFeet;

    public bool isGrab = false; 
    private ContactFilter2D contactFilter;

    //Grapin
    [HideInInspector]
    public float rangeGrab = 10.0f;
    public Vector2 stockAnchorPos; 

    //variables pour le balancement
    [HideInInspector]
    public Vector3 jointPositon = Vector3.zero;
    public float swingForce = 1f;
    public float maxSwingAngle = 45f;
   

    //Variables pour la propultion élastique
    public int moveSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        contactFilter = new ContactFilter2D();
        stopSwing();

    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition; // Obtenir la position de la souris
            mousePosition.z = 10f;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

            RaycastHit2D[] hits = new RaycastHit2D[1]; // Tableau pour stocker le résultat du raycast
            int numHits = Physics2D.Raycast(transform.position, worldPos, contactFilter, hits, rangeGrab);
            
            if (numHits > 0)
            {
                
                RaycastHit2D hit = hits[0];

                Debug.DrawRay(transform.position, worldPos - transform.position, Color.yellow, rangeGrab);
                Debug.Log(hit.transform.name);
                Debug.Log(worldPos);
                startSwing();
            }

            jointPositon = worldPos - transform.position;
            joint.anchor = jointPositon;
            joint.connectedAnchor = jointPositon;
            stockAnchorPos = new Vector2(joint.connectedAnchor.x, joint.connectedAnchor.y);
        }
    }

    void FixUpdate()
    {
       
    }


    public void stopSwing()
    {
        isGrab = false;
        joint.enabled = false;
    }

    public void startSwing()
    {
        isGrab = true;
        joint.enabled = true;
    }
}