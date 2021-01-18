using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Platform : MonoBehaviour
{
    SpriteRenderer sprite;
    ColorAndLayer converter = new ColorAndLayer();

    public float changePeriod;
    bool changing = false;
    float changeTimer = 0.0f;

    public int[] layerRotation;
    int rotationIndex = 0;

    void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();
        
        if (layerRotation.Length > 0)
        {
            changing = true;
        } 

        if (changing)
        {
            sprite.color = converter.getColorForLayer(layerRotation[0]);
            gameObject.layer = layerRotation[0];
        }
    }

    void Update() 
    {
        if (changing)
        {
            changeTimer += Time.deltaTime;
            if (changeTimer >= changePeriod)
            {
                changeTimer = 0.0f;
                rotationIndex++;
                if (rotationIndex >= layerRotation.Length)
                {
                    rotationIndex = 0;
                }
                gameObject.layer = layerRotation[rotationIndex];
                sprite.color = converter.getColorForLayer(layerRotation[rotationIndex]);
            }
        }    
    }
}
