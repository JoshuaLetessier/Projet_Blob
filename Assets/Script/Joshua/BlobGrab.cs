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
    public GameObject ressort;
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
    private SpringJoint2D springJoint;


    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        contactFilter = new ContactFilter2D();
        stopSwing();
        springJoint = ressort.GetComponent<SpringJoint2D>();

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && isGrab == false)
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
               
                //DrawRaycastInGame(transform.position, worldPos - transform.position, Color.yellow); non utilsable actuellement mettre le grab dans un sous compossant de blob
                startSwing();
            }

           
           // Debug.Log(worldPos-transform.position);
            jointPositon = worldPos - transform.position;
           // Debug.Log(jointPositon);
          
            joint.anchor = jointPositon;
            joint.connectedAnchor = jointPositon;

            springJoint.anchor = jointPositon;
            springJoint.connectedAnchor = jointPositon;
            springJoint.connectedBody = rb;

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
        rb.freezeRotation = true;

        if (transform.rotation.z > 0f)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0); 
        }
    }

    public void startSwing()
    {
        isGrab = true;
        joint.enabled = true;
        rb.freezeRotation = false;
        joint.connectedAnchor = stockAnchorPos;

        if (transform.rotation.z > 0f)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    void DrawRaycastInGame(Vector3 origin, Vector3 direction, Color color)
    {
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, origin + direction);
    }
}