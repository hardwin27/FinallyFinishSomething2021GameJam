using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    SpriteRenderer sprite;
    ColorAndLayer converter = new ColorAndLayer();
    public int layerNum = 0;

    void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();

        gameObject.layer = layerNum;
        sprite.color = converter.getColorForLayer(layerNum);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
        }
    }
}
