using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _segments = 10;


    public void DrawLine(Vector3 startPosition, Vector3 endPositin, float length)
    {
        _lineRenderer.enabled = true;

        float interpolant = Vector3.Distance(startPosition, endPositin) / length;
        float offset = Mathf.Lerp(length / 2f, 0f, interpolant);

        Vector3 startPositionDown = startPosition + Vector3.down * offset;
        Vector3 endPositionDown = endPositin + Vector3.down * offset;

        _lineRenderer.positionCount = _segments + 1;

        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            _lineRenderer.SetPosition(i, Bezier.GetPoint(startPosition, startPositionDown, endPositionDown, endPositin, (float)i / _segments));
        }
    }

    public void HideLine()
    {
        _lineRenderer.enabled = false;
    }
}
