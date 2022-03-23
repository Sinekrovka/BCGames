using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    private GameObject _player;
    private float angleDelay;

    private Vector3 cameraDelayPos;
    
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        cameraDelayPos = mainCamera.position - _player.transform.position;
        angleDelay = mainCamera.transform.eulerAngles.y - _player.transform.position.y;

    }

    private void Update()
    {
        mainCamera.position = _player.transform.position + cameraDelayPos;
        mainCamera.eulerAngles = new Vector3(mainCamera.eulerAngles.x, _player.transform.position.y+angleDelay, mainCamera.eulerAngles.z);
    }
}
