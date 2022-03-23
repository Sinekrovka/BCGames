using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PointMovement : MonoBehaviour
{
    [SerializeField] private GameObject blood;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Killed();
        }
        
        if (other.CompareTag("InteractiveEnemy"))
        {
            other.GetComponent<IInteractiveEnemy>().Interacte(transform);
        }
    }

    public void Killed()
    {
        GameObject particle = Instantiate(blood);
        particle.transform.position = transform.position;
        Destroy(particle, 1.5f);
        Destroy(gameObject);
        CrowdSpawner.Instance.KilledCreature(transform);
    }
}
