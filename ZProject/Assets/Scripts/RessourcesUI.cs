using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourcesUI : MonoBehaviour
{
    public Slider sliderHealth;
    public Slider sliderArmor;

    private void Update()
    {
        sliderHealth.value = GameManager.Instance.player.stats.currentHealth;
        sliderArmor.value = GameManager.Instance.player.stats.armor.GetValue();
    }
}
