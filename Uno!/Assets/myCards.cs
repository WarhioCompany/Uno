using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class myCards : MonoBehaviour
{
    public List<Card> cards;
    public List<GameObject> visualCards;

    public List<GameObject> blue, red, green, yellow, black;

    public float adder, yMulti;

    public float y;


    public GameObject p;

    public Vector2 size;

    // Start is called before the first frame update
    void Start()
    {
        Generate(7);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            Card c = new Card();

            c.isMid = false;
            c.value = Random.Range(0, 14);


            if (c.value > 12)
            {
                c.color = (int)Card.colors.Black;
            } else
                c.color = Random.Range(0, 3);
            cards.Add(c);
            
        }
    }

    void Spawn()
    {
        GameObject card;



        Vector2 res = Camera.main.GetComponent<screenResolution>().res;



        size = blue[0].GetComponent<RectTransform>().sizeDelta * 0.3f;

        Debug.Log(size);

        //y = res.y + (1 / -res.y * yMulti + size.y);
        float dis = 0;// (Screen.width / -2) + (size.x / 2);//-res.x + adder + size.x / 2;

        y = 0;// (-Screen.height / 2) + (size.y / 1.5f) + yMulti;
        Debug.Log(-Screen.height + " / " + 2 + " + " + size.y + " / " + 1.5f + " + " + yMulti);
        foreach(Card c in cards)
        {
            
            if(c.color == (int)Card.colors.Red)
            {
                card = Instantiate(red[c.value], new Vector2(dis, y), Quaternion.identity, p.GetComponent<RectTransform>());

            }
            else if (c.color == (int)Card.colors.Yellow)
            {
                card = Instantiate(yellow[c.value], new Vector2(dis, y), Quaternion.identity, p.GetComponent<RectTransform>());
            }
            else if (c.color == (int)Card.colors.Green)
            {
                card = Instantiate(green[c.value], new Vector2(dis, y), Quaternion.identity, p.GetComponent<RectTransform>() );
            }
            else if (c.color == (int)Card.colors.Blue)
            {
                card = Instantiate(blue[c.value], new Vector2(dis, y), Quaternion.identity, p.GetComponent<RectTransform>());
            }
            else 
            {
                card = Instantiate(black[c.value - 13], new Vector2(dis, y), Quaternion.identity, p.GetComponent<RectTransform>());
            }
            //card.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            card.AddComponent<iAmACard>().c = c;
            card.GetComponent<iAmACard>().p = gameObject;

            card.GetComponent<iAmACard>().index = visualCards.Count;
            card.GetComponent<iAmACard>().speed = 7f;

            card.GetComponent<RectTransform>().localPosition = new Vector2(dis, y);

            card.GetComponent<RectTransform>().localScale = new Vector2(0.3f, 0.3f);

            c.gO = card;

            dis += size.x  * 1.5f;

            visualCards.Add(card );
        }
    }
    public void Spawn(Vector2 pos, out GameObject card, Card c)
    {
        //card = new GameObject();



        Vector2 res = Camera.main.GetComponent<screenResolution>().res;

        y = 10;//res.y + (1 / -res.y * yMulti);

        size = blue[0].transform.localScale;

        pos = Camera.main.WorldToScreenPoint(pos);

        if (c.color == (int)Card.colors.Red)
        {
            card = Instantiate(red[c.value], pos, Quaternion.identity, p.GetComponent<RectTransform>());

        }
        else if (c.color == (int)Card.colors.Yellow)
        {
            card = Instantiate(yellow[c.value], pos, Quaternion.identity, p.GetComponent<RectTransform>());
        }
        else if (c.color == (int)Card.colors.Green)
        {
            card = Instantiate(green[c.value], pos, Quaternion.identity, p.GetComponent<RectTransform>());
        }
        else if (c.color == (int)Card.colors.Blue)
        {
            card = Instantiate(blue[c.value], pos, Quaternion.identity, p.GetComponent<RectTransform>());
        }
        else
        {
            card = Instantiate(black[c.value - 13], pos, Quaternion.identity, p.GetComponent<RectTransform>());
        }
        //card.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        card.AddComponent<iAmACard>().c = c;
        card.GetComponent<iAmACard>().p = gameObject;

        card.GetComponent<RectTransform>().localPosition = pos;


        //visualCards.Add(card);

    }

}
