using UnityEngine;

public class LandMovement : MonoBehaviour
{
    public float speed = 0.01f;
    bool canMove = true;

    public Transform mapLimit;
    public Transform limitDetector;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.beginBossFight += DisableMovement;
    }

    
    void DisableMovement()
    {
        canMove = false;
        this.enabled = false;
    }

    void FixedUpdate()
    {
        LandMoving();
        if (canMove && limitDetector.position.y < mapLimit.position.y)
        {
            DisableMovement();
        }
    }

    void LandMoving()
    {
        if (!canMove) return;
        transform.position += Vector3.down * speed * Time.fixedDeltaTime;
    }
}
