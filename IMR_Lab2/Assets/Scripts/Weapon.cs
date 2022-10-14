using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    private XRGrabInteractable interactable = null;
    private Rigidbody rb = null;

    public Transform barrel = null;
    public GameObject projectile = null;
    public float recoil = 1.0f;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        interactable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
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
        audioSource.Play();
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
        rb.AddRelativeForce(Vector3.right * recoil, ForceMode.Impulse);
    }
}
