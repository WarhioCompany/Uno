using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardInteract : MonoBehaviour
{

    public GameObject touch;
    public bool interact;

    private bool move;

    public float speed;

    private GameObject t;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            t = Instantiate(touch, mousePos, Quaternion.identity);
        }
        if (t != null)
            interact = t.GetComponent<isTouching>().touch;
        else
            interact = false;
        if (interact && t.GetComponent<isTouching>().card != null)
        {
            GameObject card = t.GetComponent<isTouching>().card;

            
            Card c = card.GetComponent<iAmACard>().c;
            
            Card midCard = GetComponent<midCard>().card.gO.GetComponent<iAmACard>().c;
            
            if(c.value == midCard.value || c.color == midCard.color || c.color == (int)Card.colors.Black)
            {
                //GetComponent<midCard>().Spawn(c);
                //Destroy(card);

                

                move = true;

                //Destroy(midCard.gO);
            }
            else
            {
                Debug.Log("cant");
            }

            if (move)
            {
                card.transform.position = Vector2.MoveTowards(card.transform.position, Vector2.zero, speed * Time.deltaTime);
                if ((Vector2)card.transform.position == Vector2.zero)
                {
                    move = false;
                    Destroy(midCard.gO);
                    
                }
            }
            else
            {
                GetComponent<midCard>().card.color = c.color;
                GetComponent<midCard>().card.value = c.value;

                //GetComponent<midCard>().card

                GetComponent<midCard>().card.gO = card;



                Debug.Log(GetComponent<midCard>().card.gO);

                interact = false;
                Destroy(t);
                t = null;
            }
        }
    }
}
