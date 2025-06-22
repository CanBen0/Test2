using UnityEngine;

public class SlicedTest : MonoBehaviour
{
    [SerializeField] GameObject testSlicedPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject sliced = Instantiate(testSlicedPrefab, new Vector3(0, 3, 0), Quaternion.identity);
            Rigidbody[] rbs = sliced.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rbs)
            {
                rb.AddForce(Vector3.right * 5f, ForceMode.Impulse);
            }

            Debug.Log("💥 Test prefab sahneye atıldı ve force verildi.");
        }
    }
}
