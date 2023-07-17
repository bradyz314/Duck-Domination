using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] Image icon;
    public Entity entity;
    [SerializeField] int index;

    void Start() {
        icon.fillAmount = 0;
    }

    void Update() {
        SkillState skill = entity.Skills[index];
        float cooldownRemaining = skill.CheckIfSkillCanBeUsed();
        if (cooldownRemaining < 0) {
            icon.fillAmount = -cooldownRemaining / skill.skillCooldown;
        } else {
            icon.fillAmount = 0;
        }
    }
}
