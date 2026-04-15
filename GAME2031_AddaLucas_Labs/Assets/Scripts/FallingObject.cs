using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private Vector2Int pointRange;

    GameManager manager;

    private int points;

    public void Initialize()
    {
        manager = FindFirstObjectByType<GameManager>();

        points = Random.Range(pointRange.x, pointRange.y);

        gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.IncrementScore(points);
            manager.IncreaseTime();
        }
        Destroy(gameObject);
    }
}
