using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] Camera cameraMain;
    [SerializeField] Transform _headTransform;

    Plane plane;
    void Start()
    {
         plane = new Plane(new Vector3(0f, 0f, 1f), Vector3.zero);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);

        float distance;

        Debug.DrawRay(ray.origin, ray.direction * 100f);
       
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        Debug.Log(distance);
        aim.position = point;

        Vector3 toAim = aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        _headTransform.rotation = Quaternion.Lerp(_headTransform.rotation , Quaternion.AngleAxis(45, new Vector3(toAim.y, -toAim.x, 0f)), Time.deltaTime * 15f);

        Debug.Log(toAim);
    }
}
