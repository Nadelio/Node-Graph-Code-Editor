using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeContextMenu : MonoBehaviour
{
    public GameObject contextMenu;
    private GameObject currentContextMenu;
    private bool isContextMenuActive = false;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(isContextMenuActive)
            {
                Destroy(currentContextMenu);
                isContextMenuActive = false;
            }
            else {
                CreateContextMenu();
            }
        }
    }

    void CreateContextMenu(){
        currentContextMenu = Instantiate(contextMenu, transform.position, Quaternion.identity);
        currentContextMenu.GetComponent<ContextMenuButtons>().passParent(gameObject);
        isContextMenuActive = true;
    }
}
