using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    [SerializeField]
    private bool right;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !right)
        {
            animator.SetBool("Fist-wolverine", !animator.GetBool("Fist-wolverine"));
            audioSource.Play();
        }
    }
}
