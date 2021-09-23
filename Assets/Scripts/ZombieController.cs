using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour

{

    public int velocityWalk = 3;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //constantes
    private const int WALK = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-velocityWalk, rb.velocity.y);
        changeAnimation(WALK);
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

    
}
