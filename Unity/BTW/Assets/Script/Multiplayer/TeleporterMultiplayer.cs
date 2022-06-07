using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class TeleporterMultiplayer : MonoBehaviour
{
    public enum TriggerType {Enter, Exit};

    [SerializeField] private Vector3 pos;
    
    [SerializeField] string tag = "Player";
    
    [SerializeField] TriggerType type;
 
    void OnTriggerEnter2D (Collider2D other)
    {

        if (type != TriggerType.Enter)
            return;

        if (tag == string.Empty || other.CompareTag(tag))
            other.transform.position += pos;
    }
 
    void OnTriggerExit2D (Collider2D other)
    {
        if (type != TriggerType.Exit)
            return;
             
        if (tag == string.Empty || other.CompareTag(tag))
            other.transform.position += pos;
    }
}
