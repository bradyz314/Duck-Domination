using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScreenButton : HoverButton
{
    public GameManager.GameState stateToSwitchTo;

    public new void OnClick() {
        GameManager.Instance.UpdateGameState(stateToSwitchTo);
    }
}
