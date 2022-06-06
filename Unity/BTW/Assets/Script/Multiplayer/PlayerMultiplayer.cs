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

    private bool _isGamePaused = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Period))
        {
            if (!_isTyping)
            {
                _isTyping = true;
            }
            else
            {
                _isTyping = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isGamePaused)
            {
                _isGamePaused = true;
            }
            else
            {
                _isGamePaused = false;
            }
        }
        else if (photonView.IsMine && !_isGamePaused && !_isTyping) // Sinon un utilisateur peu déplacer tous les joueurs
        {
            ProcessInput();
            SetAnim();
            
            if (_isMoving)
            {
                if (!audioSrc.isPlaying)
                    audioSrc.Play();
            }
            else
                audioSrc.Stop();
            
            _cam.transform.position = Vector3.SmoothDamp(transform.position, new Vector3(rb.position.x,rb.position.y,-1)  + _posOffset, ref _velocity,
                timeOffset);
        }
    }

    void ProcessInput() // Gestion deplacement
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + _dir * _speed * Time.fixedDeltaTime);
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

    void FixedUpdate()
    {

    }
}
