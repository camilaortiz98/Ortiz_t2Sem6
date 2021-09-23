using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBullerController : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
            Destroy(this.gameObject);

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);

        }

    }
}
