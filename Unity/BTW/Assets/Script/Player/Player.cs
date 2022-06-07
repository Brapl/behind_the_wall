using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool onIce;
    public bool onEnd;
    public float speed = 5f;
    public Rigidbody2D rb;
    public GameObject floorObjects;
    Vector2 dir;
    private Vector2 lastMoveDirection;
    Animator anim;
    bool l = true;
    bool r = false;
    private int points;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
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

        if (onEnd)
        {
            // Deplace le joueur au prochain étage
        }
}

    void SetAnim() // Gestion Animation
    {
        if (dir.x == 0 && dir.y == 0 && r) // Inactif  Gauche
        {
            anim.SetInteger("Mouv", 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x == 0 && dir.y == 0 && l)
        {
            anim.SetInteger("Mouv", 0); // Inactif Droite
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.x > 0) // Droite
        {
            anim.SetInteger("Mouv", 1);
            GetComponent<SpriteRenderer>().flipX = true;
            r = false;   // MaJ de l'orientation pour
            l = true;  // la prochaine inactivitee
        }
        else if (dir.x < 0) // Gauche
        {
            anim.SetInteger("Mouv", 1);
            GetComponent<SpriteRenderer>().flipX = false;
            r = true;
            l = false;
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
}
