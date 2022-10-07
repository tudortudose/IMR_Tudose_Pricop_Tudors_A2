using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public bool dying;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Die()
    {
        dying = true;
        animator.SetTrigger("dead");
    }

    public void PlayDyingSound()
    {
        audioSource.Play();
    }

    public void DistroyMe()
    {
        GameObject.Destroy(gameObject);
    }
}
