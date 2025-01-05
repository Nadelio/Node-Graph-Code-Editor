using UnityEngine;

public class Pan : MonoBehaviour
{
    public float mouseSensitivity = 0.01f;
    public float mouseSensMultiplier;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = Camera.main.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            transform.Translate(delta.x * mouseSensitivity * mouseSensMultiplier, delta.y * mouseSensitivity * mouseSensMultiplier, 0);
            lastPosition = Input.mousePosition;
        }
    }

    public void setSensMultiplier(float sensMultiplier){ mouseSensMultiplier = sensMultiplier; }
}