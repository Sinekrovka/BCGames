using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class StartGameSystem : MonoBehaviour
{
    [SerializeField] private GameObject uiSpawn;

    private GameObject _player;
    private SplineFollower _playerFollower;
    private Animator[] animPlayer;
    
    public static StartGameSystem Instance;

    private void Awake()
    {
        Instance = this;
        _player = GameObject.FindWithTag("Player");
        _playerFollower = _player.GetComponent<SplineFollower>();
        animPlayer = _player.GetComponentsInChildren<Animator>();
    }

    public void StartGame()
    {
        _playerFollower.enabled = true;
        uiSpawn.SetActive(false);
        foreach (var anim in animPlayer)
        {
            anim.SetTrigger("Run");
        }
    }
}
