using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IDamageable
{
    public float speed = 5f;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.forward, 180);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveDown();
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    void MoveDown()
    {
        direction = Vector2.down;
        EnemyMove();
    }
    void EnemyMove()
    {
        Vector3 move = direction;
        transform.position += move * Time.fixedDeltaTime;
    }
    public void Damage()
    {
        GameManager.Instance.ChangeScore(100);
        Destroy(gameObject);
    }
}
