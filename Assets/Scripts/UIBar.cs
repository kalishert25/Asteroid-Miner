using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBar : MonoBehaviour
{
    public Slider slider;
    public void SetValue(float val)
    {
        slider.value = val;
    }
    public void SetMaxValue(float val)
    {
        slider.maxValue = val;
        slider.value = val;
    }

}
