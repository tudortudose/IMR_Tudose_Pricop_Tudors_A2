using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour
{
    public float turningSpeed;

    private AudioSource audioSource;
    private Animator animator;

    public GameObject target;
    public GameObject lastTarget;
    private Vector3 targetPoint;
    private Quaternion targetRotation;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
            targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turningSpeed);
            if(Quaternion.Angle(transform.rotation, targetRotation) < 1)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        lastTarget = target;
        animator.SetTrigger("shoot");

        target = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "alien")
        {
            target = other.gameObject;
        }
    }

    public void PlayShootingSound()
    {
        lastTarget.GetComponent<AlienController>().Die();
        audioSource.Play();
    }
}
