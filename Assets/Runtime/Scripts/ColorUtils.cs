using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorUtils
{
    public static float GetSaturationPercent(int r, int g, int b)
    {
        float max = Mathf.Max(r, g, b);

        if(max == 0)
            return 0;

        float min = Mathf.Min(r, g, b);

        return ((max-min)/max) * 100;
    }

    public static float GetBrightPercent(int r, int g, int b)
    {
        return Mathf.Max(r, g, b)/255.0f * 100;
    }
}