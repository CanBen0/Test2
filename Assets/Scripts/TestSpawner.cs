using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject testSlicedPrefab;

    void Start()
    {
        GameObject sliced = Instantiate(testSlicedPrefab, Vector3.zero, Quaternion.identity);
        Rigidbody[] bodies = sliced.GetComponentsInChildren<Rigidbody>();
        Debug.Log("🎯 Rigidbody Sayısı: " + bodies.Length);
    }
}

