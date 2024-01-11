using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;

    private bool isFiring = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isFiring)
            {
                StartCoroutine(FireProjectile());
            }
        }
        else
        {
            StopCoroutine(FireProjectile());
            isFiring = false;
        }
    }

    IEnumerator FireProjectile()
    {
        isFiring = true;

        while (Input.GetButton("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation)
                as Rigidbody;

            instantiatedProjectile.velocity = transform.forward * speed;

            yield return new WaitForSeconds(0.1f);
        }

        isFiring = false;
    }
}
