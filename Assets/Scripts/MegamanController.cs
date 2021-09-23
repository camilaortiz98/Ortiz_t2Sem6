using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanController : MonoBehaviour
{
    public int velocityX = 7;
    public float jumpForce = 40;

    public GameObject rightBullet;
    public GameObject leftBullet;

    public GameObject MediumrightBullet;
    public GameObject MediumleftBullet;

    public GameObject BigRightBullet;
    public GameObject BigLeftBullet;

    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //private bool x_presionada = false;

    //constantes
    private const int IDLE = 0;
    private const int RUN = 1;
    private const int JUMP = 2;
    private const int RUN2 = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUN2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUN2);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            
            //crearemos el objeto
            var bullet = sr.flipX ? leftBullet : rightBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = rightBullet.transform.rotation;
            Instantiate(bullet, position, rotation);
            
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            var mediumBullet = sr.flipX ? MediumleftBullet : MediumrightBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = MediumrightBullet.transform.rotation;
            Instantiate(mediumBullet, position, rotation);

        }
        

        if (Input.GetKeyUp(KeyCode.B))
        {
            var bigBullet = sr.flipX ? BigLeftBullet : BigRightBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = BigRightBullet.transform.rotation;
            Instantiate(bigBullet, position, rotation);
        }
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
