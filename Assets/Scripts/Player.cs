using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    UIManager ui;
    SlingShotManager sling;
    public static int counter = 0;
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
                StartCoroutine(DeathofEnemy(collision.gameObject));
                
            }
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
