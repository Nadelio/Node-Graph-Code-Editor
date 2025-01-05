using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuButtons : MonoBehaviour
{
    private GameObject parent;
    private static GameObject temp;

    public void Delete(){
        Destroy(parent);
        Destroy(gameObject);
    }

    public void Duplicate(){
        Instantiate(parent, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Copy(){
        Camera.main.GetComponent<Clipboard>().Copy(parent);
        Destroy(gameObject);
    }

    public void Cut(){
        temp = Instantiate(parent);
        Camera.main.GetComponent<Clipboard>().Copy(temp);
        Destroy(parent);
        Destroy(gameObject);
        temp.SetActive(false);
    }

    public static void DestroyTemp(){ Destroy(temp); }

    public void passParent(GameObject parent){
        this.parent = parent;
    }
}
