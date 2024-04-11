using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class winGame : MonoBehaviour
{
    public TakeObject takeObject;
    public Canvas canvas;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && takeObject.isTake == true) 
        {
            canvas.enabled = true;
        }
    }
}
