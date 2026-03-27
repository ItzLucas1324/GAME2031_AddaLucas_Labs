using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CommandPlayer : MonoBehaviour
{
    [SerializeField] private float moveStep = 1.0f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Color currentColor => spriteRenderer != null ? spriteRenderer.color : Color.white;

    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * moveStep;
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * moveStep;
    }

    public void ChangeColor(Color color)
    {
        if (spriteRenderer == null) return;

        spriteRenderer.color = color;
    }
}
