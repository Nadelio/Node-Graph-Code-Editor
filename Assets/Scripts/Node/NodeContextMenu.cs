using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeContextMenu : MonoBehaviour
{
    public GameObject contextMenu;
    private GameObject currentContextMenu;
    private bool isContextMenuActive = false;

    void Update()
    {
        if (isContextMenuActive && Input.GetMouseButtonDown(0)) { if (!IsPointerOverUIObject()) { Destroy(currentContextMenu); isContextMenuActive = false; } }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) {
            if (isContextMenuActive) { Destroy(currentContextMenu); isContextMenuActive = false; }
            else { CreateContextMenu(); }
        }
    }

    void CreateContextMenu() {
        currentContextMenu = Instantiate(contextMenu, transform.position, Quaternion.identity);
        currentContextMenu.GetComponent<ContextMenuButtons>().passParent(gameObject);
        isContextMenuActive = true;
    }

    private bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
