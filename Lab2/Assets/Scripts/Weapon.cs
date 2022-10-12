using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    private XRGrabInteractable interactable = null;
    private Rigidbody rigidbody = null;

    public Transform barrel = null;
    public GameObject projectile = null;
    public float recoil = 1.0f;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        interactable.onActivate.AddListener(Fire);
    }

    private void OnDisable()
    {
        interactable.onActivate.RemoveListener(Fire);
    }

    private void Fire(XRBaseInteractor interactor)
    {
        CreateProjectile();
        ApplyRecoil();
    }

    private void CreateProjectile()
    {
        GameObject projectileObject = Instantiate(projectile, barrel.position, barrel.rotation);
        Projectile bullet = projectileObject.GetComponent<Projectile>();
        bullet.Launch();
    }

    private void ApplyRecoil()
    {
        rigidbody.AddRelativeForce(Vector3.right * recoil, ForceMode.Impulse);
    }
}
