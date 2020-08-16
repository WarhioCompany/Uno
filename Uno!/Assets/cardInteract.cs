using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardInteract : MonoBehaviour
{

    public GameObject touch;
    public bool interact;

    public GameObject mid;

    public bool move;

    public float speed;

    private GameObject t;

    private GameObject cardTouch;

    private Card midC, cardTouchC;

    public List<GameObject> midCards;

    private void Start()
    {
        mid = GetComponent<midCard>().card.gO;
        midC = mid.GetComponent<iAmACard>().c;

        
    }

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
        if (interact && !move)
        {
            cardTouch = t.GetComponent<isTouching>().card;
            cardTouchC = cardTouch.GetComponent<iAmACard>().c;

            //Debug.Log("value: " + midC.value + " " + cardTouchC.value + " (" + (midC.value == cardTouchC.value) + ")" + "\n\tcolor: " + midC.color + " " + cardTouchC.color + " (" + (midC.color == cardTouchC.color) + ")");

            //check
            if((cardTouchC.value == midC.value || cardTouchC.color == midC.color || cardTouchC.color == (int)Card.colors.Black))
            {
                Debug.Log("Yes!");
                move = true;

                

                mid = cardTouch;
                midC.value = cardTouchC.value;
                midC.color = cardTouchC.color;

                midCards.Add(mid);

                for (int i = 0; i < midCards.Count; i++)
                {
                    midCards[i].GetComponent<SpriteRenderer>().sortingOrder = i + 1;
                }

            }
            else
            {
                Debug.Log("No!");
                GameObject toDestroy = t;
                Destroy(toDestroy);
            }
        }
        else if (move)
        {
            cardTouch.transform.position = Vector2.MoveTowards(cardTouch.transform.position, Vector2.zero, speed * Time.deltaTime);
            if ((Vector2)cardTouch.transform.position == Vector2.zero)
            {
                move = false;

                

                GameObject toDestroy = t;
                Destroy(toDestroy);
            }
        }
    }
}
