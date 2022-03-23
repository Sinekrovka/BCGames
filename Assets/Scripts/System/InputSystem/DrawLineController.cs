using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineController : MonoBehaviour
{
    [SerializeField] private float Zposition;
    private LineRenderer lineRend;
    
    private void Start()
    {
        InputController.Instance.hold += StartDraw;
        InputController.Instance.endHold += EndDraw;
        lineRend = GetComponent<LineRenderer>();
    }

    private void StartDraw(Vector3 startPoint)
    {
        startPoint.z = Zposition;
        lineRend.positionCount++;
        lineRend.SetPosition(lineRend.positionCount-1, startPoint);
    }

    private void EndDraw()
    {
        lineRend.positionCount = 0;
    }

}
