using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Level;

public class ActionButton : MonoBehaviour
{
    public TextMeshProUGUI text; 
    public Image icon;
    public Button button;

    public void SetUp(Action action)
    {
        this.icon.sprite = ActionDataBank.Instance.GetActionIcon(action.iconType);
        this.text.text = action.text;
        button.onClick.AddListener(action.action);
    }
}
