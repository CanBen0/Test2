using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject[] cubePrefabs; // 🎯 4 yönlü prefab listesi
    public Transform spawnPoint;
    public float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnCube", 1f, spawnInterval);
    }

    void SpawnCube()
    {
        // Rastgele bir prefab seç
        int index = Random.Range(0, cubePrefabs.Length);
        GameObject selectedPrefab = cubePrefabs[index];

        // Instantiate et
        Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
    }
}
