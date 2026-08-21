using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;

    public int minRange = 2;
    public int maxRange = 4;

    public float fireTime = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireWeapon());
    }

    void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    IEnumerator FireWeapon()
    {
        int attackRate = Random.Range(minRange, maxRange);
        for (int i = 0; i <= attackRate; i++)
        {
            yield return new WaitForSeconds(fireTime);
            Fire();
        }
    }
}
