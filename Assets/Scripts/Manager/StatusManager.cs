using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager Instance;
    public enum StatusType {
        None, Attack, Speed, DOT, Shield
    }
    #region Status Factories
    AttackStatusFactory attackStatusFactory;
    SpeedStatusFactory speedStatusFactory;
    DOTStatusFactory dotStatusFactory;
    ShieldStatusFactory shieldStatusFactory;
    #endregion
    #region Status Icons
    [SerializeField] Sprite attackBuffIcon;
    [SerializeField] Sprite attackDebuffIcon;
    [SerializeField] Sprite speedBuffIcon;
    [SerializeField] Sprite speedDebuffIcon;
    [SerializeField] Sprite healIcon;
    [SerializeField] Sprite burnIcon;
    [SerializeField] Sprite shieldIcon;
    [SerializeField] Sprite shieldSprite;
    #endregion
    
    void Start()
    {
        if (Instance == null) {
            InitializeFactories();
            StatusManager.Instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    void InitializeFactories() {
        attackStatusFactory = ScriptableObject.CreateInstance<AttackStatusFactory>();
        speedStatusFactory = ScriptableObject.CreateInstance<SpeedStatusFactory>();
        dotStatusFactory = ScriptableObject.CreateInstance<DOTStatusFactory>();
        shieldStatusFactory = ScriptableObject.CreateInstance<ShieldStatusFactory>();
        shieldStatusFactory.SetIcon(shieldIcon);
        shieldStatusFactory.shieldSprite = shieldSprite;
    }

    public void ApplyStatusEffect(StatusData data, Entity target) {
        switch(data.type) {
            case StatusType.Attack:
                UpdateAttackStatusAndApply(data.percentage, data.duration, target);
                break;
            case StatusType.Speed:
                UpdateSpeedStatusAndApply(data.percentage, data.duration, target);
                break;
            case StatusType.DOT:
                UpdateDOTStatusAndApply(data.damage, data.tickTime, data.duration, target);
                break;
            case StatusType.Shield:
                UpdateShieldStatusAndApply(data.shieldHealth, data.duration, target);
                break;
        }
    }

    void UpdateAttackStatusAndApply(float percentage, float duration, Entity target) {
        attackStatusFactory.SetValues(percentage, duration);
        attackStatusFactory.SetIcon((percentage > 0) ? attackBuffIcon : attackDebuffIcon);
        attackStatusFactory.GetStatus(target).Apply();
    }

    void UpdateSpeedStatusAndApply(float percentage, float duration, Entity target) {
        speedStatusFactory.SetValues(percentage, duration);
        speedStatusFactory.SetIcon((percentage > 0) ? speedBuffIcon : speedDebuffIcon);
        speedStatusFactory.GetStatus(target).Apply();
    }

    void UpdateDOTStatusAndApply(float damage, float tickTime, float duration, Entity target) {
        dotStatusFactory.SetValues(damage, tickTime, duration);
        dotStatusFactory.SetIcon((damage < 0) ? healIcon : burnIcon);
        dotStatusFactory.GetStatus(target).Apply();
    }

    void UpdateShieldStatusAndApply(float shieldHealth, float duration, Entity target) {
        shieldStatusFactory.SetValues(shieldHealth, duration);
        shieldStatusFactory.GetStatus(target).Apply();
    }
}
