using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectNeighbours : MonoBehaviour
{
    private float collisionAreaDistance = 10.25F;
    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.GetComponent<Renderer>().bounds.center, 
                                                        this.collisionAreaDistance);

        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.GetType() == this.gameObject.GetType())
            {
                Destroy(this.gameObject);
            }
        }
    }
}
