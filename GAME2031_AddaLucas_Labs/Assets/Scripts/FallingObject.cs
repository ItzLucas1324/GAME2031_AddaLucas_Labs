using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private Vector2Int pointRange;

    private int points;

    public void Initialize()
    {
        points = Random.Range(pointRange.x, pointRange.y);

        gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController playerController))
        {
            playerController.IncrementScore(points);
        }
        Destroy(gameObject);
    }
}
