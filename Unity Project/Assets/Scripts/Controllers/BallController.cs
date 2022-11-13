using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] GameObject hitParticle;
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] LevelManager levelManager;
    [SerializeField] int hazardLayer = 6;
    [HideInInspector] public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(hitClip);
        Instantiate(hitParticle, collision.GetContact(0).point, Quaternion.identity, levelManager.transform);
        if (collision.collider.gameObject.layer == hazardLayer)
        {
            levelManager.LevelFailed();
        }
    }
}
