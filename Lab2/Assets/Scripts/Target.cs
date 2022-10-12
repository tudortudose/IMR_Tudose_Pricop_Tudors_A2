using System;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [Serializable] public class HitEvent : UnityEvent<int> { }
    public HitEvent OnHit = new HitEvent();

    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tag: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Projectile"))
        {
            ComputeOutScore(collision.transform.position);
        }
    }

    private void ComputeOutScore(Vector3 hitPosition)
    {
        float distanceFromCenter = Vector3.Distance(transform.position, hitPosition);
        int score = 0;

        Debug.Log("Score: ");
        Debug.Log(score);

        if(distanceFromCenter < 0.25f)
        {
            score = 100;
            particleSystem.Play();
        }
        else if(distanceFromCenter < 0.5f)
        {
            score = 50;
        }
        else if(distanceFromCenter < 0.75f)
        {
            score = 25;
        }
        else if(distanceFromCenter < 1.0f)
        {
            score = 10;
        }

        OnHit.Invoke(score);
    }
}
