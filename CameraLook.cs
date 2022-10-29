using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public static float MouseSensetivity = 120f;

    float xRotation = 0f;

    public Transform Player;

    public bool CursorLocked;

    // Start is called before the first frame update
    void Start()
    {
        CursorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        float MouseX = Input.GetAxis("Mouse X") * MouseSensetivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensetivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Player.Rotate(MouseX * Vector3.up);
        //Player.Rotate(MouseSensetivity * MouseY * Vector3.left);

        Vector3 eulerRotation = Player.transform.rotation.eulerAngles;
        Player.transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0 * Time.deltaTime);
    }
}
