using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerMultiplayer : MonoBehaviourPunCallbacks
{
    float _speed = 5f;
    public Rigidbody2D rb;
    public Vector3 _posOffset;
    public float timeOffset;
    private Vector3 _velocity;
    private bool _isMoving;
    private bool _isTyping;
    public AudioSource audioSrc;
    Vector2 _dir;
    Animator _anim;
    Camera _cam;
    bool _l = true;
    bool _r = false;
    public static PlayerMultiplayer instance;
    
    private Vector2 lastMoveDirection;
    public bool onIce;
    public bool onEnd;
    private int points;

    private bool _isGamePaused = false;
    
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
        _anim = GetComponent<Animator>();
        _cam = Camera.main;
    }

    private void Update()
    {
        if (!onEnd && photonView.IsMine)
        {
            // Gestion deplacement
            _dir.x = Input.GetAxisRaw("Horizontal");
            _dir.y = Input.GetAxisRaw("Vertical");
            if (!onIce)
            {
                rb.MovePosition(rb.position + _dir * _speed * Time.fixedDeltaTime);
                SetAnim();
            }
            // Deplacement sur glace
            if (_dir.x != 0 || _dir.y != 0)
                lastMoveDirection = _dir;
            if (onIce)
            {
                _dir = lastMoveDirection;
                rb.MovePosition(rb.position + _dir * _speed * Time.fixedDeltaTime);
                SetAnim();
            }
        }
    }

    void ProcessInput() // Gestion deplacement
    {
        // Gestion deplacement
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");
        if (!onIce)
        {
            rb.MovePosition(rb.position + _dir * _speed * Time.fixedDeltaTime);
            SetAnim();
        }
        // Deplacement sur glace
        if (_dir.x != 0 || _dir.y != 0)
            lastMoveDirection = _dir;
        if (onIce)
        {
            _dir = lastMoveDirection;
            rb.MovePosition(rb.position + _dir * _speed * Time.fixedDeltaTime);
            SetAnim();
        }
            
        if (_isMoving)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
            audioSrc.Stop();
    }

    void SetAnim() // Gestion Animation
    {
        if (_dir.x == 0 && _dir.y == 0 && _r) // Inactif  Gauche
        {
            _anim.SetInteger("Mouv", 0);
            GetComponent<SpriteRenderer>().flipX = false;
            _isMoving = false;
        }
        else if (_dir.x == 0 && _dir.y == 0 && _l)
        {
            _anim.SetInteger("Mouv", 0); // Inactif Droite
            GetComponent<SpriteRenderer>().flipX = true;
            _isMoving = false;
        }
        else if (_dir.x > 0) // Droite
        {
            _anim.SetInteger("Mouv", 1);
            GetComponent<SpriteRenderer>().flipX = true;
            _r = false;   // MaJ de l'orientation pour
            _l = true;  // la prochaine inactivitee
            _isMoving = true;
        }
        else if (_dir.x < 0) // Gauche
        {
            _anim.SetInteger("Mouv", 1);
            GetComponent<SpriteRenderer>().flipX = false;
            _r = true;
            _l = false;
            _isMoving = true;
        }
        else if (_dir.x==0)
        {
            _isMoving = true; 
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
        rb.velocity = new Vector2(_dir.x, rb.velocity.y);
    }
}
