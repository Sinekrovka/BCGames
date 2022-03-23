using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrel : MonoBehaviour, IInteractiveEnemy
{
    [SerializeField] private GameObject destroyParticle;
    public void Interacte(Transform obj)
    {
        obj.GetComponent<PointMovement>().Killed();
        GameObject particle = Instantiate(destroyParticle);
        particle.transform.position = transform.position;
        Destroy(particle, 1.5f);
        Destroy(gameObject);
    }
}
