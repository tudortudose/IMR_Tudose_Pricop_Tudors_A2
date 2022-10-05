using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapeToPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;
    private ARRaycastManager aRRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();   
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
        }
    }
}
