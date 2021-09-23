using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public List<Collider2D> listaObjetos = new List<Collider2D>() { };

    public float velocityX = 10f;

    // Start is called before the first frame update
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
            Destroy(this.gameObject);

        
        if (other.gameObject.tag == "Enemy")
        {
            listaObjetos.Add(other);

            Debug.Log(listaObjetos.Count);

            Destroy(other.gameObject);

        }

    }

    /*void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            listaObjetos.Remove(other);
            Debug.Log("Tiene: " + listaObjetos.Count);

        }
    }*/
}
