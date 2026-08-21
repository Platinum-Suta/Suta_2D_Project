using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject missilePrefab;

    public float projectileFireTime = 0.2f;
    public float missileFireTime = 1f;

    bool alive;
    float coolDown = 1f;

    private void OnEnable()
    {
        alive = true;
        StartCoroutine(ProjectileShooting());
        StartCoroutine(MissileShooting());
    }

    private void OnDisable()
    {
        alive = false;
        StopAllCoroutines();
    }

    void FireProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    void FireMissile()
    {
        Instantiate(missilePrefab, transform.position, Quaternion.identity);
    }

    IEnumerator ProjectileShooting()
    {
        while (alive)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(projectileFireTime);
                FireProjectile();
            }
            yield return new WaitForSeconds(coolDown);
        }
    }

    IEnumerator MissileShooting()
    {
        while (alive)
        {
            yield return new WaitForSeconds(missileFireTime);
            FireMissile();
        }
    }
}
