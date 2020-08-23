
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PackScript : MonoBehaviour
{

    private myCards m;

    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<myCards>();
        Debug.Log(m.gameObject.name);

    }

    public void Click()
    {
        Spawn(Generate(), new Vector2(m.y, Check()), m.p.transform);
    }

    private float Check()
    {
        
        float dis = 0;

        foreach(GameObject c in m.visualCards)
        {
            if (c.GetComponent<RectTransform>().localPosition.x != dis)
            {
                return dis;
            }
            dis += m.size.x * 1.5f;
        }
        return dis;
    }

    public Card Generate()
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
        return card;
    }

    public GameObject Spawn(Card c, Vector2 dis, Transform p)
    {
        int co = c.color;
        GameObject g;
        if(co == 0)
        {
            g = Instantiate(m.red[c.value], dis, Quaternion.identity, p);
        } else if(co == 1)
        {
            g = Instantiate(m.green[c.value], dis, Quaternion.identity, p);
        }
        else if (co == 3)
        {
            g = Instantiate(m.blue[c.value], dis, Quaternion.identity, p);
        }
        else
        {
            g =  Instantiate(m.yellow[c.value], dis, Quaternion.identity, p);
        }
        g.transform.localScale = dis;
        return g;
    }
}
