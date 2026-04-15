using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fallingObjectPrefab;
    [SerializeField] private GameObject fallingHazardPrefab;
    [SerializeField] private float ySpawnPosition;
    [SerializeField] private Vector2 xSpawnRange;

    GameManager manager;

    void Start()
    {
        manager = FindFirstObjectByType<GameManager>();
        StartCoroutine(SpawnFallingObject());
    }
    
    private IEnumerator SpawnFallingObject()
    {
        while (true && manager.isAlive)
        {
            int result = Random.Range(0, 11);

            if (result >= 3)
            {
                GameObject go = Instantiate(fallingObjectPrefab, GetSpawnPosition(), Quaternion.identity);
                go.GetComponent<FallingObject>().Initialize();
            }
            else
            {
                GameObject ho = Instantiate(fallingHazardPrefab, GetSpawnPosition(), Quaternion.Euler(0f, 0f, 180f));
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        return new Vector3(Random.Range(xSpawnRange.x, xSpawnRange.y), ySpawnPosition, 0.0f);
    }
}
