using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAndLayer
{
    Color[] availableColor = {
        new Color(236/255.0f, 228/255.0f, 183/255.0f), //Neutral
        new Color(152/255.0f, 193/255.0f, 217/255.0f), //Blue
        new Color(127/255.0f, 176/255.0f, 105/255.0f), //Green
        new Color(238/255.0f, 108/255.0f, 77/255.0f) //Red
    };
    public Color getColorForLayer(int layer)
    {
        return availableColor[layer - 8];
    }
}
