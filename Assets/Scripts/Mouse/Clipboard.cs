using System.Collections;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    private static GameObject copiedObject;
    private bool isPasteKeyPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V))
        {
            if (!isPasteKeyPressed)
            {
                isPasteKeyPressed = true;
                StartCoroutine(HandlePasteKeyPress());
            }
        }
    }

    private IEnumerator HandlePasteKeyPress()
    {
        Paste();
        yield return new WaitForSeconds(0.1f); // Adjust the duration as needed
        isPasteKeyPressed = false;
    }

    void Paste()
    {
        if (copiedObject == null) { Debug.LogError("obj is null"); return; }
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        curPosition.z = 0;
        copiedObject.SetActive(true);
        Instantiate(copiedObject, curPosition, Quaternion.identity);
        ContextMenuButtons.DestroyTemp();
    }

    public void Copy(GameObject obj) { copiedObject = obj; }
}
