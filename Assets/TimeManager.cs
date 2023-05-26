using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeScale = 0.2f;
    [SerializeField] private float _startFixedDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = _timeScale;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
