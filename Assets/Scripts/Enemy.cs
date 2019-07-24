using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool disperse;
    public GameObject Effect;
    SlingShotManager sling;
   public bool dead,moving,rotating;
    UIManager ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        sling = GameObject.Find("SlingShot").GetComponent<SlingShotManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter(Collision collision )
    {

        if (collision.gameObject.tag == "Enemy" )
        {
           // collision.gameObject.GetComponent<SphereCollider>().enabled = false;
           if(moving)
            {

                collision.gameObject.GetComponent<ITweenMagic>().enabled = false;
                collision.gameObject.GetComponent<iTween>().enabled = false;
            }
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("collidererererer");
            Player.counter++;
            if (Player.counter >= sling.totalEnimiesInLevel)
            {

                ui.Victory.SetActive(true);
            }
        }
    }
}
