using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTouching : MonoBehaviour
{

    public GameObject card;

    
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
        
    }
}
