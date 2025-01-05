using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    private static GameObject copiedObject;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.V)){
                Paste();
            }
        }
    }

    void Paste(){
        if(copiedObject == null){
            return;
        }
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        curPosition.z = 0;
        Instantiate(copiedObject, curPosition, Quaternion.identity);
    }

    public void Copy(GameObject obj){
        copiedObject = obj;
    }
}
