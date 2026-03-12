using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 5;

    [SerializeField] private float maxSpeed = 5;

    private Rigidbody2D rb2D;

    private float input;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb2D.linearVelocityX) <= maxSpeed)
        {
            rb2D.AddForceX(input * moveForce);
        }
        else
        {
            if (Mathf.Sign(input) != Mathf.Sign(rb2D.linearVelocityY))
            {
                rb2D.AddForceX(input * moveForce);
            }
        }
            
    }
}
