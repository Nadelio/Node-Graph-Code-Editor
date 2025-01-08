using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toolbox : MonoBehaviour
{
    [SerializeField] private GameObject TestNode;

    public void OnStateChange(){
        int val = gameObject.GetComponent<TMP_Dropdown>().value;
        switch(val){
            case 0:
                break;
            case 1:
                Instantiate(TestNode, Vector3.zero, Quaternion.identity);
                break;
        }
        gameObject.GetComponent<TMP_Dropdown>().value = 0;
    }
}
