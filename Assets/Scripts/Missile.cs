using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IDamageable
{
    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(GetPlayerLocation().x - transform.position.x, GetPlayerLocation().y - transform.position.y);
        direction.Normalize();
        transform.up = direction;
    }

    Vector3 GetPlayerLocation()
    {
        return GameManager.Instance.playerLocation.position;
    }

    
    void FixedUpdate()
    {
        rb.velocity = direction * speed;
        if (Mathf.Abs(transform.position.y) > 10 || Mathf.Abs(transform.position.x) > 10)
        {
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        Destroy(gameObject);
        GameManager.Instance.ChangeScore(75);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        collision.gameObject.GetComponent<IDamageable>().Damage();

    }
}
