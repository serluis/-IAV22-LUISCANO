using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float mainSpeed = 30.0f; //vel normal
    float shiftAdd = 50.0f;  //vel con shift pulsado (correr)
    float maxShift = 100.0f; //vel max
    public float camSens = 0.01f;   //sensibilidad giro
    private Vector3 lastMouse = new Vector3(255, 255, 255); // posicion del raton
    private float totalRun = 1.0f; //tiempo del desplazamiento

    void Update()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        
        float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0)
        { // only move while a direction key is pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                totalRun += Time.deltaTime;
                p = p * totalRun * shiftAdd;
                p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
                p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
                p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
            }
            else
            {
                totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                p = p * mainSpeed;
            }

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.Space))
            { //If player wants to move on X and Z axis only
                transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            }
            else
            {
                transform.Translate(p);
            }
        }
    }

    //Controles
    private Vector3 GetBaseInput()
    { 
        Vector3 vec = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            vec += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            vec += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec += new Vector3(1, 0, 0);
        }
        return vec;
    }
}
