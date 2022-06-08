using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity,
            timeOffset);
    }

    void movecam(Vector3 pos)
    {
        this.transform.position = pos;
    }
}
