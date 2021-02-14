using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Bar : MonoBehaviour
{
    protected Slider BarSlider;

    private void Awake()
    {
        BarSlider = GetComponent<Slider>();
        BarSlider.maxValue = 1; //normalized
    }

    public void OnValueChanged(int value, int maxValue)
    {
        BarSlider.value = (float)value / maxValue;
    }
}
