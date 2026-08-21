using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    Vector2 direction;
    

    public float speed = 10f;

    public float rightWall = 10f;
    public float leftWall = -10f;
    public float bottomWall = -7f;
    public float topWall = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = GameManager.Instance.inputActions.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 move = direction;
        transform.position += move * speed * Time.fixedDeltaTime;
        move = transform.position;
        move.x = Mathf.Clamp(move.x, leftWall, rightWall);
        move.y = Mathf.Clamp(move.y, bottomWall, topWall);
        transform.position = move;
    }
    public void Damage()
    {
        
        GameManager.Instance.GameOver();
    }
}
