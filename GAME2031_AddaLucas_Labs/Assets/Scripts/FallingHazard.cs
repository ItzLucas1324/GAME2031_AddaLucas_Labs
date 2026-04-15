using UnityEngine;

public class FallingHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController playerController))
        {
            playerController.OnHit();
        }
        Destroy(gameObject);
    }
}
