using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour {
    public float dragSpeed = 0.5f;
    private Vector3 dragOrigin;
    void Start() {
        
    }

    void Update() {
        // Set initial position
/*         if (Input.GetMouseButtonDown(0)) {
            dragOrigin = Input.mousePosition;
        }

        // While mouse down drag camera
        if (Input.GetMouseButton(0)) {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
        
            transform.Translate(move, Space.World);  
        }

        // Rotate
        if (Input.GetMouseButton (1)) {    
            transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * dragSpeed);
        } */

        // Zoom
        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if (ScrollWheelChange != 0) {
            float R = dragSpeed * ScrollWheelChange * 10;
            float PosX = Camera.main.transform.eulerAngles.x + 90;
            float PosY = -1 * (Camera.main.transform.eulerAngles.y - 90);

            PosX = PosX / 180 * Mathf.PI;
            PosY = PosY / 180 * Mathf.PI;

            float X = R * Mathf.Sin(PosX) * Mathf.Cos(PosY);
            float Z = R * Mathf.Sin(PosX) * Mathf.Sin(PosY);
            float Y = R * Mathf.Cos(PosX);

            float CamX = Camera.main.transform.position.x;
            float CamY = Camera.main.transform.position.y;
            float CamZ = Camera.main.transform.position.z;

            transform.position = new Vector3(CamX + X, CamY + Y, CamZ + Z);
        }
    }
}
