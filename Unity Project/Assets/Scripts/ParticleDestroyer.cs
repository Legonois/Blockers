using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    [SerializeField] float lifeTime;
    private void Start()
    {
        StartCoroutine(Lifetime());
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
