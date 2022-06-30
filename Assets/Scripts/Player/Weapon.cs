using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;

    public GameObject bulletPrefab;
    public AudioManager audio;

    public Animator anim;

    public float fireRate = 0.15f;
    private float fireRateReset;

    private bool hasNotShot;

    
    void Awake() {
        fireRateReset += fireRate;
        audio = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();

        hasNotShot = true;

    }

    void FixedUpdate() {

        if (hasNotShot && Input.GetMouseButton(0)) {
            Shoot();
            hasNotShot = false;
        }

        if (Input.GetMouseButton(0)) {

            fireRate -= Time.deltaTime;

            if (fireRate <= 0) {
                fireRate = fireRateReset;
                Shoot();
            }
        } else if (!Input.GetMouseButton(0) && anim.GetBool("shooting")) {
            fireRate = fireRateReset;
            anim.SetBool("shooting", false);
            hasNotShot = true;
        }
    }

    void Shoot() {
        audio.Play("TurretShot");
        anim.SetBool("shooting", true);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
