using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListManager : MonoBehaviour
{
    public bool isLeft;
    public List<List<GameObject>> lists;

    private List<GameObject> listOfVisualCards;

    public GameObject player;

    private myCards scr;

    private Vector2 res;

    private float sizeX, adder;

    public int maxCards;

    // Start is called before the first frame update
    void Start()
    {
        lists = new List<List<GameObject>>();

        maxCards = 0;
        scr = player.GetComponent<myCards>();
        listOfVisualCards = scr.visualCards;

        sizeX = scr.size.x;
        adder = scr.adder;

        res = GetComponent<screenResolution>().res;

        
        lists.
            Add
            (listOfVisualCards);

        float range = res.x - adder - sizeX / 2;
        float dis = -range;

        while(dis + adder + sizeX * 2 < range)
        {
            maxCards++;
            dis += sizeX * 2;
        }
        Debug.Log("Max cards: " + maxCards);

    }

    // Update is called once per frame
    void Update()
    {
        listOfVisualCards = scr.visualCards;
        

    }
}
