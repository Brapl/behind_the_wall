using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMouv : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float movespeed = 0.5f;
    public Animator animator;
    public bool isInRange;
    public int damageOnCollision;
    public static EnemyMouv instance;

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de EnemyMouv dans la scène");
            return;	
        }
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerHealth.instance.died && !Exit.instance.finished)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
            SetAnim(direction);
        }
        else
        {
            animator.SetInteger("dir", 0);
        }
    }
    void SetAnim(Vector2 direction) 
    {
        if (direction.x == 0 && direction.y == 0) 
        {
            animator.SetInteger("dir", 0);
        }
        else if (direction.x > 0.5)
        {
            animator.SetInteger("dir", 1);
        }
        else if (direction.x < (-0.5))
        {
            animator.SetInteger("dir", 3);
        }
        else if (direction.x <=Math.Abs(0.5) && direction.y > 0)
        {
            animator.SetInteger("dir", 4);
        }
        else if (direction.x <=Math.Abs(0.5) && direction.y < 0)
        {
            animator.SetInteger("dir", 2);
        }

        if (isInRange)
        {
            animator.SetInteger("dir", 0);
        }
    }

    private void FixedUpdate()
    {
        if (isInRange == false && !PlayerHealth.instance.died && !Exit.instance.finished)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isInRange = true;
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
