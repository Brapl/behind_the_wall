using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    Vector2 dir;
    public Animator anim;
    bool l = true;
    bool r = false;
    AudioSource audioSrc;
    bool isMoving = false;
    public static Player instance;

    private Vector2 lastMoveDirection;
    public bool onIce;
    public bool onEnd;
    private int points;

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Player dans la scène");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!onEnd)
        {
            // Gestion deplacement
            dir.x = Input.GetAxisRaw("Horizontal");
            dir.y = Input.GetAxisRaw("Vertical");
            if (!onIce)
            {
                rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
                SetAnim();
            }
            // Deplacement sur glace
            if (dir.x != 0 || dir.y != 0)
                lastMoveDirection = dir;
            if (onIce)
            {
                dir = lastMoveDirection;
                rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
                SetAnim();
            }
            
            if (isMoving)
            {
                if (!audioSrc.isPlaying)
                    audioSrc.Play();
            }
            else
                audioSrc.Stop();
        }
        
    }

    void SetAnim() // Gestion Animation
    {
        if (dir.x == 0 && dir.y == 0 && r) // Inactif  Gauche
        {
            anim.SetInteger("Mouv", 0);
            GetComponent<SpriteRenderer>().flipX = false;
            isMoving = false;
        }
        else if (dir.x == 0 && dir.y == 0 && l)
        {
            anim.SetInteger("Mouv", 0); // Inactif Droite
            GetComponent<SpriteRenderer>().flipX = true;
            isMoving = false;
        }
        else if (dir.x > 0) // Droite
        {
            anim.SetInteger("Mouv", 1);
            GetComponent<SpriteRenderer>().flipX = true;
            r = false;   // MaJ de l'orientation pour
            l = true;  // la prochaine inactivitee
            isMoving = true;
        }
        else if (dir.x < 0) // Gauche
        {
            anim.SetInteger("Mouv", 1);
            GetComponent<SpriteRenderer>().flipX = false;
            r = true;
            l = false;
            isMoving = true;
        }
        else if (dir.x==0)
        {
            isMoving = true; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "IceFloor")
        {
            onIce = true;
        }
        if (collision.tag == "EndFloor")
        {
            onEnd = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "IceFloor")
        {
            onIce = false;
        }
        if (collision.tag == "EndFloor")
        {
            onEnd = false;
        }
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dir.x, rb.velocity.y);
        
    }
}
