using System.Collections;
using System.Collections.Generic;
using Level;
using UnityEngine;
using Singletons;
using UnityEngine.EventSystems;

public class UIManager : UnityInSceneSingleton<UIManager>
{
    public EmoteMenu emoteMenu;
    public GameObject actionButtonPrefab;
    public Transform actionButtonParent;
    private const float MENU_DIST_EXIT_THRESHOLD = 3;
    private const float ACTION_MENU_PADDING = 1;
    public bool actionMenuOpen;

    public void PopulateActionsMenu(List<Action> actions, Vector3 mousePos)
    {
        if(actionMenuOpen) return;

        foreach(var action in actions)
        {
            ActionButton actionButton = Instantiate(actionButtonPrefab, actionButtonParent).GetComponent<ActionButton>();
            actionButtonParent.position = mousePos;
            actionButton.SetUp(action);
        }
        if(actions.Count > 0)
        {
            actionMenuOpen = true;
        }

    }

    public void TurnOffActionMenu()
    {
        foreach(Transform child in actionButtonParent)
        {
            Destroy(child.gameObject);
        }
        actionMenuOpen = false;
    }

    public bool WordUICheck()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        foreach(var obj in results)
        {
            if(results[0].gameObject.layer == LayerMask.NameToLayer(Consts.LAYER_WORLD_SPACE_UI))
            {
                return true;
            }
        }
            return false;
    }

    public GameObject GetUiObject(Vector3 Input)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        foreach(var obj in results)
        {
            return results[0].gameObject;
        }
        return null;
    }

    public void RunEmoteMenu(Transform headAnchor)
    {
        emoteMenu.Run(headAnchor);
    }
}
