using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    [SerializeField] private GameObject loseUI;
    [SerializeField] private GameObject loseParticles;

    public static LoseSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Lose()
    {
        loseUI.SetActive(true);
        loseParticles.SetActive(true);
    }
}
