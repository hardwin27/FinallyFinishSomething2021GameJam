using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaChangerTrigger : MonoBehaviour
{
    public PlayerControl otherCharacter = null;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            otherCharacter = other.gameObject.GetComponent<PlayerControl>();
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            otherCharacter = null;
        }
    }
}
