using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midCard : MonoBehaviour
{
    private List<GameObject> red, green, blue, yellow; 
    public List<GameObject> midCards;

    public Card card;

    public GameObject player , p;

    // Start is called before the first frame update
    void Awake()
    {
        myCards s = player.GetComponent<myCards>();
        red = s.red;
        green = s.green;
        blue = s.blue;
        yellow = s.yellow;

        int color = Random.Range(0, 3);
        int value = Random.Range(0, 9);

        card.color = color;
        card.value = value;

        GameObject g;

        Spawn(card, out g);

        
        card.gO = g;
        g.AddComponent<iAmACard>().c = card;

        midCards.Add(g);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Card card, out GameObject g)
    {
        if (card.color == (int)Card.colors.Red)
        {
            g = Instantiate(red[card.value], Vector2.zero, Quaternion.identity, p.transform);

        }
        else if (card.color == (int)Card.colors.Yellow)
        {
            g = Instantiate(yellow[card.value], Vector2.zero, Quaternion.identity, p.transform);
        }
        else if (card.color == (int)Card.colors.Green)
        {
            g = Instantiate(green[card.value], Vector2.zero, Quaternion.identity, p.transform);
        }
        else //if (card.color == (int)Card.colors.Blue)
        {
            g = Instantiate(blue[card.value], Vector2.zero, Quaternion.identity, p.transform);
        }

        g.GetComponent<RectTransform>().localScale = new Vector2(0.3f, 0.3f);
    }
}
