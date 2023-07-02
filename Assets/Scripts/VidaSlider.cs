using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaSlider : MonoBehaviour
{
    public Slider healthSlider;

    public void SetMaxHealth(float health){
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void Health(float health){
        healthSlider.value = health;
    }
}
