using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public Light2D flashlight = new Light2D();
    public float z;
    public int battery = 300;
    

    // Start is called before the first frame update
    void Start()
    {
        flashlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Light"))
        {
            flashlight.enabled = !flashlight.enabled;
            if (flashlight.enabled)
                InvokeRepeating("decreaseBattery",1f,1f);
            if (!flashlight.enabled)
                CancelInvoke();
        }

        if (Input.GetKey("up") || Input.GetKey("w"))
            z = 0;
        else if (Input.GetKey("left") || Input.GetKey("a"))
            z = 90;
        else if (Input.GetKey("down") || Input.GetKey("s"))
            z = 180;
        else if (Input.GetKey("right") || Input.GetKey("d"))
            z = 270;
        if (flashlight != null)
        {
            flashlight.transform.eulerAngles = new Vector3(0, 0, z);

            if (battery <= 0)
                flashlight.enabled = false;
        }
    }

    void decreaseBattery()
    {
        if (battery > 0)
            battery -= 1;
    }
}


