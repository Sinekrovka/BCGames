using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyButton : MonoBehaviour, IInteractiveEnemy
{
    [SerializeField] private Transform cone;
    public void Interacte(Transform obj)
    {
        cone.DOMoveY(-0.2f, 0.5f);
    }
}
