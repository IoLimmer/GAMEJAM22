using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public float accuracy = 0;
    private Vector3 addthis;

    public Camera fpsCam;
    public ParticleSystem beam;
    public GameObject impactEffect;

    private float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        addthis.x = 0;
        addthis.y = 0;
        addthis.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        addthis.x = accuracy;
        addthis.y = accuracy;
        addthis.z = accuracy;

        if (Input.GetButtonDown("Fire1") && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + addthis, out hit, range))
        {
            Debug.Log(hit.transform.name);
            beam.Play();
            target target = hit.transform.GetComponent<target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }
}
