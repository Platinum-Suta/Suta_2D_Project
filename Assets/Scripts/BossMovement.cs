using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour, IDamageable
{
    int health = 100;
    int maxHealth = 100;
    public float speed = 2f;
    bool moveRight = true;

    public Transform Healthbar;

    void Start()
    {
        GameManager.Instance.beginBossFight += BeginBossFight;
        gameObject.SetActive(false);
        Healthbar.gameObject.SetActive(false);
    }

    void BeginBossFight()
    {
        gameObject.SetActive(true);
        Healthbar.gameObject.SetActive(true);
    }

    public void Damage()
    {
        TakeDamage();
    }
    void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
            // boss is defeated
            GameManager.Instance.WinGame();
        }
        float ratio = (float)health / (float)maxHealth;
        if (ratio < 0)
            ratio = 0;
        Vector3 scale = Vector3.one;
        scale.x = ratio;
        Healthbar.localScale = scale;
    }

    float rightLimit = 8f;
    float leftLimit = -8f;
    float bossYLevel = 2.5f;

    private void FixedUpdate()
    {
        Vector3 move = Vector3.right;
        if (!moveRight)
            move = -move;

        if (transform.position.y > bossYLevel)
        {
            move.y = -1;
        }
        transform.position += move * speed * Time.fixedDeltaTime;

        if (transform.position.x > rightLimit)
        {
            moveRight = false;
        }
        else if (transform.position.x < leftLimit)
        {
            moveRight = true;
        }
    }
}
