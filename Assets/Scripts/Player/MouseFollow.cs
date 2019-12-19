using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public Transform start;
    private Camera cam; 
    public void Awake()
    {
        cam = Camera.main; 
    } 
    void Update()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 10;
        Vector3 destination = cam.ScreenToWorldPoint(screenPoint);
        transform.position = destination;
    }

}
