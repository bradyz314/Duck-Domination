using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatusFactory: ScriptableObject
{
    public Sprite effectIcon;
    
    public void SetIcon(Sprite icon) {
        effectIcon = icon;
    }
    public abstract Status GetStatus(Entity target);
}

public class Status {
    public Entity target;
    public Sprite effectIcon;
    protected GameObject appliedEffect;

    public virtual void Apply() {
        AddIconToTargetStatusBar();
    }

    void AddIconToTargetStatusBar() {
        appliedEffect = new GameObject();
        Image icon = appliedEffect.AddComponent<Image>();
        icon.sprite = effectIcon;
        appliedEffect.transform.SetParent(target.statusBar);
        appliedEffect.transform.localScale = new Vector3(1, 1, 1);
        appliedEffect.SetActive(true);
    }

    protected void RemoveIconFromTargetStatusBar() {
        GameObject.Destroy(appliedEffect);
    }
}
