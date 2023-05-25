using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] Camera cameraMain;
    [SerializeField] Transform _headTransform;
    [SerializeField] Transform _lightSaberTransform;
    [SerializeField] bool check;
    [SerializeField] float offsetPositionSaber = 1f;

    Plane plane;
    void Start()
    {
         plane = new Plane(new Vector3(0f, 0f, 1f), Vector3.zero);
         Cursor.visible = false;
         Cursor.lockState = CursorLockMode.Confined;
    }

   
    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);

        float distance;

    
       
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        aim.position = point;

        Vector3 toAim = aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        _headTransform.rotation = Quaternion.Lerp(_headTransform.rotation , Quaternion.AngleAxis(45, new Vector3(toAim.y, -toAim.x, 0f)), Time.deltaTime * 15f);


    }

    private void Update()
    {
        _lightSaberTransform.localEulerAngles = new Vector3(_lightSaberTransform.localEulerAngles.x, -transform.localEulerAngles.y, _lightSaberTransform.localEulerAngles.z);
        if (transform.rotation.y < 0)
        {
            _lightSaberTransform.localPosition = new Vector3(-offsetPositionSaber, _lightSaberTransform.localPosition.y, _lightSaberTransform.localPosition.z);
        }
        else
        {
            _lightSaberTransform.localPosition = new Vector3(offsetPositionSaber, _lightSaberTransform.localPosition.y, _lightSaberTransform.localPosition.z);
        }
    }
}
