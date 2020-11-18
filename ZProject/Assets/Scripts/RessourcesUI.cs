using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourcesUI : MonoBehaviour
{
    public Slider sliderHealth;

    private void Update()
    {
        sliderHealth.value = GameManager.Instance.player.health;
    }
}
