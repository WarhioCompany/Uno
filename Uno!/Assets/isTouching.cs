using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTouching : MonoBehaviour
{

    public GameObject card;

    private float cd = 0.25f;
    
    public bool touch;
    private void Start()
    {
        touch = false;

    }
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            touch = true;
            card = collision.gameObject;
        } 
        
        
    }
    private void Update()
    {
        cd -= Time.deltaTime;
        if(cd <= 0)
        {
            Destroy(gameObject);
        }
    }
}
