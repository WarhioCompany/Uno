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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        touch = true;
        card = collision.gameObject;
    }
}
