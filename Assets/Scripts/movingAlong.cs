using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAlong : MonoBehaviour
{
    public bool moving;
    
    // Start is called before the first frame update
    void Start()
    {
        if(moving)
        {
            transform.GetComponent<ITweenMagic>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
