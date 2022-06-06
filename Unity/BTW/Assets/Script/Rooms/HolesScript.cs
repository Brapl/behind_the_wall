using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesScript : MonoBehaviour
{
    public GameObject current;
    public GameObject target;
    public int x,y;
    public Rigidbody2D rb;
    private int teleported = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teleported > 0)
        {
            if (teleported == 1)
                target.SetActive(true);
            teleported--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            rb = collision.attachedRigidbody;
            if (teleported== 0)
            {
                rb.transform.position += new Vector3(x, y);
                
                teleported += 1000;
                target.SetActive(false);
            }



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
        }
    }
}
