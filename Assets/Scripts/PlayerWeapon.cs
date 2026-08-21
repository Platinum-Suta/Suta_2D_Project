using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        GameManager.Instance.inputActions.Player.Attack.performed += Fire;
    }

    private void OnDisable()
    {
        GameManager.Instance.inputActions.Player.Attack.performed -= Fire;
    }

    void Fire(InputAction.CallbackContext context)
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
