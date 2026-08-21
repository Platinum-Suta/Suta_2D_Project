using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageable
{
    public float speed = 100f;
    Rigidbody2D rb;

    public bool moveDown = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 move = new Vector2(0, speed);
        if (moveDown)
            move.y = -move.y;
        rb.velocity = move;

        //These deletes the projectile if it goes too far 
        if (transform.position.y > 30 || transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        collision.gameObject.GetComponent<IDamageable>().Damage();
        
    }
    public void Damage()
    {
        Debug.Log("Happen!");
        GameManager.Instance.ChangeScore(50);
        Destroy(gameObject);
    }
}
