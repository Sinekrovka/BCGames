using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCreatures : MonoBehaviour, IInteractiveEnemy
{
    public void Interacte(Transform objectTransform)
    {
        CrowdSpawner.Instance.AddCreature();
    }
}
