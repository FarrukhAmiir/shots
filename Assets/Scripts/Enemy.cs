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
    float speed;
    bool hit = false;
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
        if(hit)
        {

            gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity.normalized * speed ;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            speed = collision.relativeVelocity.magnitude * 0.5f;
            Debug.Log(speed);
            hit = true;
            // collision.gameObject.GetComponent<SphereCollider>().enabled = false;
            if (moving)
            {

                collision.gameObject.GetComponent<ITweenMagic>().enabled = false;
                collision.gameObject.GetComponent<iTween>().enabled = false;
            }
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            // collision.gameObject.transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GameObject effect = Instantiate(Effect);
            effect.transform.position = collision.gameObject.transform.position;
            Player.counter++;
            StartCoroutine(DeathofEnemy(collision.gameObject));

        }
        else if (collision.gameObject.tag == "Enemy")
        {

            speed = collision.relativeVelocity.magnitude * 0.5f;
            Debug.Log(speed);
        }
    }

    IEnumerator DeathofEnemy(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        Destroy(obj);
        Destroy(gameObject);
        if (Player.counter >= sling.totalEnimiesInLevel)
        {

            ui.Victory.SetActive(true);
        }

    }
}
