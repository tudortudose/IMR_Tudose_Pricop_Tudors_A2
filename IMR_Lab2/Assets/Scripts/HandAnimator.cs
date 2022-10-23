using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    private Animator animator;


    public void setFist(bool play)
    {
        animator.SetBool("Fist-wolverine", play);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("Fist-wolverine", !animator.GetBool("Fist-wolverine"));
        }
    }
}
