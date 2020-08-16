using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenResolution : MonoBehaviour
{ 

    public Vector2 res;

    // Start is called before the first frame update
    void Awake()
    {
        res = Camera.main.ScreenToWorldPoint(Screen.width * Vector2.right);
        Debug.Log(res);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
