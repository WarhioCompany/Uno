using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class myCards : MonoBehaviour
{

    public List<Card> cards;

    public List<GameObject> blue, red, green, yellow, black;

    public float adder, yMulti;

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

            int isSpecial = Random.Range(0,100);

            if (isSpecial >= 51)
                c.isSpecial = true;
            else
                c.isSpecial = false;


            if (c.isSpecial)
            {
                c.value =10 + Random.Range(0, 4);
                
            }
            else
            {
               c.value = Random.Range(0, 9);
            }


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
        Vector2 size = blue[0].transform.localScale;
        float dis = -res.x + adder + size.x / 2;
        foreach(Card c in cards)
        {
            //Debug.Log(new Vector2(dis, res.y + (1 / -res.y * yMulti)));
            Debug.Log(" 1 / " + res.y + " * " + yMulti);
            if(c.color == (int)Card.colors.Red)
            {
                card = Instantiate(red[c.value], new Vector2(dis, res.y + (1 / -res.y * yMulti)), Quaternion.identity);

            }
            else if (c.color == (int)Card.colors.Yellow)
            {
                card = Instantiate(yellow[c.value], new Vector2(dis, res.y + (1 / -res.y * yMulti)), Quaternion.identity);
            }
            else if (c.color == (int)Card.colors.Green)
            {
                card = Instantiate(green[c.value], new Vector2(dis, res.y + (1 / -res.y * yMulti)), Quaternion.identity);
            }
            else if (c.color == (int)Card.colors.Blue)
            {
                card = Instantiate(blue[c.value], new Vector2(dis, res.y + (1 / -res.y * yMulti)), Quaternion.identity);
            }
            else 
            {
                card = Instantiate(black[c.value - 13], new Vector2(dis, res.y + (1 / -res.y * yMulti)), Quaternion.identity);
            }
            card.AddComponent<iAmACard>().c = c;

            c.gO = card;

            dis += size.x * 2;
        }
    }

}
