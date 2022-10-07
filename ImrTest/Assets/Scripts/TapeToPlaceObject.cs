using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapeToPlaceObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjectsToInstantiate;

    [SerializeField]
    private UIController uIController;
    
    private AudioSource audioSource;

    private GameObject spawnedObject;
    private ARRaycastManager aRRaycastManager;
    private Vector2 touchPosition;

    private bool screenPressed;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            screenPressed = false;
            return;
        }

        if(aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon) && !screenPressed)
        {
            screenPressed = true;

            var hitPose = hits[0].pose;

            int entityIndex = uIController.activeEntityIndex;

            audioSource.Play();

            Instantiate(gameObjectsToInstantiate[entityIndex], hitPose.position, hitPose.rotation);
        }
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Input.touches.Select(touch => touch.fingerId).Any(id => EventSystem.current.IsPointerOverGameObject(id)))
            {
                touchPosition = default;
                return false;
            }

            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }
}
