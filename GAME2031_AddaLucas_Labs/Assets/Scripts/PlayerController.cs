using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 5;

    [SerializeField] private float maxSpeed = 5;

    [SerializeField] private TMP_Text scoreText;

    private Rigidbody2D rb2D;

    private float input;

    private int score;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetScore(0);
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

    private void SetScore(int newScore)
    {
        this.score = newScore;

        scoreText.text = $"Score: {newScore}";
    }

    public void IncrementScore(int incrementor)
    {
        SetScore(this.score + incrementor);
    }
}
