using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject winParticles;

    public static WinSystem Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        winParticles.SetActive(true);
        winUI.SetActive(true);
    }
}
