using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midCard : MonoBehaviour
{
    private List<GameObject> red, green, blue, yellow;

    public Card card;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
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

        if (card.color == (int)Card.colors.Red)
        {
            g = Instantiate(red[card.value], Vector2.zero, Quaternion.identity);

        }
        else if (card.color == (int)Card.colors.Yellow)
        {
            g = Instantiate(yellow[card.value], Vector2.zero, Quaternion.identity);
        }
        else if (card.color == (int)Card.colors.Green)
        {
            g = Instantiate(green[card.value], Vector2.zero, Quaternion.identity);
        }
        else 
        {
            g = Instantiate(blue[card.value], Vector2.zero, Quaternion.identity);
        }

         
        card.gO = g;
        g.AddComponent<iAmACard>().c = card;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Card card)
    {
        if (card.color == (int)Card.colors.Red)
        {
            Instantiate(red[card.value], Vector2.zero, Quaternion.identity);

        }
        else if (card.color == (int)Card.colors.Yellow)
        {
            Instantiate(yellow[card.value], Vector2.zero, Quaternion.identity);
        }
        else if (card.color == (int)Card.colors.Green)
        {
            Instantiate(green[card.value], Vector2.zero, Quaternion.identity);
        }
        else if (card.color == (int)Card.colors.Blue)
        {
            Instantiate(blue[card.value], Vector2.zero, Quaternion.identity);
        }
    }
}
