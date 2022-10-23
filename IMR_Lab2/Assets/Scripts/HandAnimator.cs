using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    private Animator animator;

    private Animation fistAnimation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fistAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fistAnimation.isPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Fist");
            fistAnimation.Play("Fist-wolverine");
        }
    }
}
