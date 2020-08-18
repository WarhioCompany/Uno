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

        y = res.y + (1 / -res.y * yMulti);

        size = blue[0].transform.localScale;
        float dis = -res.x + adder + size.x / 2;
        foreach(Card c in cards)
        {
            
            if(c.color == (int)Card.colors.Red)
            {
                card = Instantiate(red[c.value], new Vector2(dis, y), Quaternion.identity, p.transform);

            }
            else if (c.color == (int)Card.colors.Yellow)
            {
                card = Instantiate(yellow[c.value], new Vector2(dis, y), Quaternion.identity, p.transform);
            }
            else if (c.color == (int)Card.colors.Green)
            {
                card = Instantiate(green[c.value], new Vector2(dis, y), Quaternion.identity, p.transform);
            }
            else if (c.color == (int)Card.colors.Blue)
            {
                card = Instantiate(blue[c.value], new Vector2(dis, y), Quaternion.identity, p.transform);
            }
            else 
            {
                card = Instantiate(black[c.value - 13], new Vector2(dis, y), Quaternion.identity, p.transform);
            }
            card.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            card.AddComponent<iAmACard>().c = c;

            c.gO = card;

            dis += size.x * 2;

            visualCards.Add(card);
        }
    }
    public void Spawn(Vector2 pos, out GameObject card, Card c)
    {
        //card = new GameObject();



        Vector2 res = Camera.main.GetComponent<screenResolution>().res;

        y = res.y + (1 / -res.y * yMulti);

        size = blue[0].transform.localScale;
        
        

            if (c.color == (int)Card.colors.Red)
            {
                card = Instantiate(red[c.value], pos, Quaternion.identity, p.transform);

            }
            else if (c.color == (int)Card.colors.Yellow)
            {
                card = Instantiate(yellow[c.value], pos, Quaternion.identity, p.transform);
            }
            else if (c.color == (int)Card.colors.Green)
            {
                card = Instantiate(green[c.value], pos, Quaternion.identity, p.transform);
            }
            else if (c.color == (int)Card.colors.Blue)
            {
                card = Instantiate(blue[c.value], pos, Quaternion.identity, p.transform);
            }
            else
            {
                card = Instantiate(black[c.value - 13], pos, Quaternion.identity, p.transform);
            }
        card.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            card.AddComponent<iAmACard>().c = c;

            

            
            //visualCards.Add(card);
        
    }

}
