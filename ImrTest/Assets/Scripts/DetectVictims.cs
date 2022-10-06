using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectVictims : MonoBehaviour
{
    void onTriggerEnter()
    {
        Destroy(this.gameObject);
    }   
}
