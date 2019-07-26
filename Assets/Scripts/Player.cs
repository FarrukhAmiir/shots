using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    UIManager ui;
    SlingShotManager sling;
    public static int counter = 0;
    bool hit;
    Rigidbody rb;
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        sling = GameObject.Find("SlingShot").GetComponent<SlingShotManager>();
        rb = gameObject.GetComponent<Rigidbody>();
        vel = rb.velocity;
        Debug.Log(vel);
    }

    // Update is called once per frame
    void Update()
    {
       
        

    }

    private void LateUpdate()
    {
        if(!hit)
        {
            Debug.Log("slingspeed" + sling.speed);
            rb.velocity = sling.speed * rb.velocity.normalized;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Wall")
        {
           
        }

        else if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Wney");
            if (!collision.gameObject.GetComponent<Enemy>().dead)
            {
                hit = true;
                if(collision.gameObject.GetComponent<Enemy>().rotating)
                {
                    collision.gameObject.GetComponent<RotateAround>().enabled = false;
                }
                else if (collision.gameObject.GetComponent<Enemy>().moving)
                {
                    collision.gameObject.GetComponent<ITweenMagic>().enabled = false;
                    collision.gameObject.GetComponent<iTween>().enabled = false;
                }
                collision.gameObject.GetComponent<Enemy>().dead = true;
                GameObject effect = Instantiate(collision.gameObject.GetComponent<Enemy>().Effect);
                effect.transform.position = collision.gameObject.transform.position;
                counter++;
                Debug.Log(counter);
                StartCoroutine(DeathofEnemy(collision.gameObject));
            }
        }

        else if(collision.gameObject.tag == "Bomb")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DeathofEnemy(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        Destroy(obj);
        Destroy(gameObject);
        if (counter >= sling.totalEnimiesInLevel)
        {
           
            ui.Victory.SetActive(true);
        }
        
    }
}
