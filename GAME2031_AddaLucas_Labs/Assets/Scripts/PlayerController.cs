using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 5;

    [SerializeField] private float maxSpeed = 5;

    private Rigidbody2D rb2D;

    private float input;

    public int health;

    private PlayerInput playerInput;

    GameManager gameManager;

    public event Action playerDeath;

    public event Action<int> takeDamage;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb2D = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
        playerInput.Player.Move.performed += Move;
        playerInput.Player.Move.canceled += Move;
    }

    private void OnDisable()
    {
        playerInput.Player.Move.performed -= Move;
        playerInput.Player.Move.canceled -= Move;
        playerInput.Player.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (gameManager.isAlive)
        {
            if (Mathf.Abs(rb2D.linearVelocityX) <= maxSpeed)
            {
                rb2D.AddForceX(input * moveForce);
            }
            else
            {
                if (Mathf.Sign(input) != Mathf.Sign(rb2D.linearVelocityX))
                {
                    rb2D.AddForceX(input * moveForce);
                }
            }
        }
    }

    public void OnHit()
    {
        health--;

        if (health <= 0)
        {
            Death();
        }

        takeDamage?.Invoke(health);
    }

    public void Death()
    {
        playerDeath?.Invoke();
    }
}
