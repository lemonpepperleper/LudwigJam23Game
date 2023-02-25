using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetValue(float val)
    {
        if (val < 0)
        {
            val = 0;
        }

        slider.value = val;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxValue(float val)
    {
        slider.maxValue = val;
        slider.value = val;
        fill.color = gradient.Evaluate(1f);
    }
}
