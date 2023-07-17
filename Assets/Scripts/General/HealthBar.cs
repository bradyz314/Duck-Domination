using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _healthBarSprite;
    [SerializeField] Transform healthBarTransform;

    public void UpdateHealthBar(float maxHealth, float currHealth) {
        _healthBarSprite.fillAmount = currHealth / maxHealth;
    }
}
