using System;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [Serializable] public class HitEvent : UnityEvent<int> { }
    public HitEvent OnHit = new HitEvent();

    private ParticleSystem particleSystem;

    private Transform thrower1 = null;
    private Transform thrower2 = null; 

    private void Awake()
    {
        particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tag: " + collision.gameObject.tag);
        Debug.Log("Has gun? " + GameObject.FindGameObjectWithTag("Gun1"));

        thrower1 = GameObject.FindGameObjectWithTag("Gun1").transform;
        thrower2 = GameObject.FindGameObjectWithTag("Gun2").transform;

        if (collision.gameObject.CompareTag("Projectile"))
        {
            ComputeOutScore(collision.transform.position, false, thrower1);
        }
        else if (collision.gameObject.CompareTag("Projectile2"))
        {
            ComputeOutScore(collision.transform.position, true, thrower2);
        }
        else //for any other object there is a minimum score when colliding
        {
            OnHit.Invoke(5);
        }
    }

    private void ComputeOutScore(Vector3 hitPosition, bool isVariant, Transform gunPosition)
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

        if (isVariant)
        {
            score *= 2;
        }

        if(gunPosition != null)
        {
            Debug.Log("Distance: " + (Vector3.Distance(gunPosition.position, hitPosition)));
            score *= (int) (Vector3.Distance(gunPosition.position, hitPosition) * 10);
        }

        OnHit.Invoke(score);
    }
}
