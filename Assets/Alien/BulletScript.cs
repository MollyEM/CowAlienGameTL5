using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals("Platform"))
        {
            Debug.Log("Miss!");
            Destroy(gameObject);
        } 
        
        if (col.gameObject.name.Equals("DaCow"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
