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

    private myCards scr;

    private GameObject t;

    private GameObject cardTouch;


    public GameObject midP, p;

    private Card midC, cardTouchC;

    public List<GameObject> midCards;

    private void Start()
    {
        mid = Camera.main.GetComponent<midCard>().card.gO;
        midC = mid.GetComponent<iAmACard>().c;
        scr = GetComponent<myCards>();
        
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

            if (cardTouch.GetComponent<iAmACard>() != null)
            {
                cardTouchC = cardTouch.GetComponent<iAmACard>().c;
                //check
                if ((cardTouchC.value == midC.value || cardTouchC.color == midC.color || cardTouchC.color == (int)Card.colors.Black) && !cardTouchC.isMid)
                {
                    Debug.Log("Yes!");
                    move = true;

                    cardTouchC.isMid = true;
                    cardTouch.GetComponent<iAmACard>().c.isMid = true;

                    cardTouch.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
                    cardTouch.transform.SetParent(midP.transform);

                    mid = cardTouch;
                    midC.value = cardTouchC.value;
                    midC.color = cardTouchC.color;

                    midCards.Add(mid);

                    for (int i = 0; i < midCards.Count; i++)
                    {
                        midCards[i].GetComponent<SpriteRenderer>().sortingOrder = i + 1;
                    }

                }
            }
            //Перепиши, дегенерат
            else if (cardTouch.name == "Pack")
            {
                bool get = false;

                float adder = scr.adder;
                float sizeX = scr.size.x;


                Vector2 res = Camera.main.GetComponent<screenResolution>().res;

                float dis = -res.x + adder + sizeX / 2;

                int count = scr.visualCards.Count;

                Debug.Log(count);

                if (!get)
                {

                    for (int i = 0; i <= count; i++)
                    {

                        Debug.Log(get);


                        if (i >= scr.visualCards.Count)
                        {
                            Card card = new Card();
                            card.isMid = false;
                            card.value = Random.Range(0, 14);


                            if (card.value > 12)
                            {
                                card.color = (int)Card.colors.Black;
                            }
                            else
                                card.color = Random.Range(0, 3);

                            GameObject cardV;// = new GameObject();
                            scr.Spawn(new Vector2(dis, scr.y), out cardV, card);
                            card.gO = cardV;

                            cardV.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                            cardV.transform.SetParent(p.transform);

                            scr.visualCards.Add(cardV);
                            scr.cards.Add(card);

                            Debug.Log("Spawn");
                            get = true;

                            break;
                        }
                        else
                        {
                            GameObject c = scr.visualCards[i];

                            if (c.transform.position.x != dis)

                            {
                                Card card = new Card();
                                card.isMid = false;
                                card.value = Random.Range(0, 14);


                                if (card.value > 12)
                                {
                                    card.color = (int)Card.colors.Black;
                                }
                                else
                                    card.color = Random.Range(0, 3);

                                GameObject cardV;// = new GameObject();
                                scr.Spawn(new Vector2(dis, scr.y), out cardV, card);
                                card.gO = cardV;

                                cardV.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                                cardV.transform.SetParent(p.transform);

                                scr.visualCards[i] = cardV;
                                scr.cards[i] = card;

                                Debug.Log("Spawn");
                                get = true;
                                break;
                                
                            }

                        }
                        dis += sizeX * 2;


                    }
                    Destroy(t);
                }
            }
            else
            {
                Debug.Log("No!");
                GameObject toDestroy = t;
                Destroy(toDestroy);
            }
        }
        //Середина
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
