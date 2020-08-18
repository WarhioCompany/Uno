using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class scrollMove : MonoBehaviour
{
    public float speed;
    public GameObject o;

    private bool move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (move) {
    //        for (int i = 0; i < Input.touchCount; i++)
    //        {
    //            Touch t = Input.GetTouch(i);
    //            if (t.phase == TouchPhase.Ended)
    //            {
    //                move = false;
    //            }
    //        }

    //        if (Input.GetMouseButtonUp(0))
    //        {
    //            move = false;
    //        }

    //        o.transform.Translate(speed * Time.deltaTime * Vector2.right);
    //    }
        
    //}



    //public void Click()
    //{
    //    move = true;
    //}

    private void OnMouseDrag()
    {
        o.transform.Translate(speed * Time.deltaTime * Vector2.right);
    }

    private void OnMouseDown()
    {
        Debug.Log("Enter");
    }

    public void Click()
    {
        o.transform.Translate(speed * Time.deltaTime * Vector2.right);
    }
}
