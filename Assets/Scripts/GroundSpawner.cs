using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private FloorTile groundPrefab; 
    [SerializeField] private Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        nextSpawnPoint = Instantiate(groundPrefab, nextSpawnPoint, Quaternion.identity)
                            .Setup(this)
                            .transform.GetChild(1)
                            .transform.position;
    }

    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            SpawnTile();
        }
    }
}
