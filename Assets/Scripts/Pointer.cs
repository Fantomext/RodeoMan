using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField]Transform aim;
    [SerializeField] Camera cameraMain;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(new Vector3(0f,0f,-1f), Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        aim.position = point;
    }
}
