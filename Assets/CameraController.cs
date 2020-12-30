﻿
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public float panBorderThickness = 10f;

    public Vector2 panLimit;
    public float scrollSpeed = 20f;
public float minY = 10f;
public float maxY = 50f;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness ){
            pos.z += panSpeed * Time.deltaTime;
        }if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness ){
            pos.z -= panSpeed * Time.deltaTime;
        }if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness ){
            pos.x += panSpeed * Time.deltaTime;
        }if(Input.GetKey("a") || Input.mousePosition.x <=  panBorderThickness ){
            pos.x -= panSpeed * Time.deltaTime;
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y-= scroll*scrollSpeed*100*Time.deltaTime;
        

        pos.x = Mathf.Clamp(pos.x,-panLimit.x,panLimit.x);
        pos.y = Mathf.Clamp(pos.y,minY,maxY);
        pos.z = Mathf.Clamp(pos.z,-panLimit.x,panLimit.y);

        transform.position = pos;
    }
}
