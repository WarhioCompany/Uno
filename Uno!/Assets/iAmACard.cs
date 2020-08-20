using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Experimental.UIElements;

public class iAmACard : MonoBehaviour
{
    public Card c;
    public GameObject p;

    public int index;

    private bool move;

    private RectTransform tr;

    public float speed;

    private void Start()
    {
        Debug.Log(name + ": Start");

        Button b = GetComponent<Button>();

        UnityEngine.Events.UnityAction action1 = () => { Click(); };

        b.onClick.AddListener(action1);

        tr = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (move)
        {
            tr.position = Vector2.MoveTowards(tr.position, Vector2.zero, speed * Time.deltaTime);
        }
    }

    public void Click()
    { 

       

        if (Check(c))
        {

            Debug.Log("filnally");

            if (!move)
            {
                gameObject.transform.SetParent(Camera.main.GetComponent<midCard>().midCards[Camera.main.GetComponent<midCard>().midCards.Count - 1].transform);

                c.isMid = true;
                Camera.main.GetComponent<midCard>().card = c;
                Camera.main.GetComponent<midCard>().midCards.Add(gameObject);

                myCards m = p.GetComponent<myCards>();

                m.visualCards[index] = null;

                move = true;


                
            }
        }
    }

    public bool Check(Card cardTouchC)
    {
        Card midC = Camera.main.GetComponent<midCard>().card;
        return (cardTouchC.value == midC.value || cardTouchC.color == midC.color || cardTouchC.color == (int)Card.colors.Black) && !cardTouchC.isMid;
    }
}
