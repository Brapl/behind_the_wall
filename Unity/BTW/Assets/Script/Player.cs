using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    Vector2 dir;
    Animator anim;
    bool l = true;
    bool r = false;

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
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);

        SetAnim(); 
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

    void FixedUpdate()
    {
        
    }
}
