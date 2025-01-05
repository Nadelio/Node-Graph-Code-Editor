using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuButtons : MonoBehaviour
{
    private GameObject parent;

    public void Delete(){
        Destroy(parent);
        Destroy(gameObject);
    }

    public void Duplicate(){
        Instantiate(parent, transform.position, Quaternion.identity);
    }

    public void Copy(){
        Camera.main.GetComponent<Clipboard>().Copy(parent);
    }

    public void Cut(){
        Copy();
        Delete();
    }

    public void passParent(GameObject parent){
        this.parent = parent;
    }
}
