using System.Collections;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public GameObject slicedVersionUp;
    public GameObject slicedVersionDown;
    public GameObject slicedVersionLeft;
    public GameObject slicedVersionRight;

    public InputManager.Direction correctDirection;

    public float explosionForce = 8f;
    public float torqueForce = 10f;

    public void Slice(InputManager.Direction swipeDir)
    {
        GameObject slicedVersion = null;

        switch (swipeDir)
        {
            case InputManager.Direction.Up:
                slicedVersion = slicedVersionUp;
                break;
            case InputManager.Direction.Down:
                slicedVersion = slicedVersionDown;
                break;
            case InputManager.Direction.Left:
                slicedVersion = slicedVersionLeft;
                break;
            case InputManager.Direction.Right:
                slicedVersion = slicedVersionRight;
                break;
        }

        if (slicedVersion != null)
        {
            GameObject sliced = Instantiate(slicedVersion, transform.position, transform.rotation);
            StartCoroutine(ActivateAndExplode(sliced));
        }
        else
        {
            Debug.LogWarning("❗ slicedVersion atanmadı!");
        }
    }

    private IEnumerator ActivateAndExplode(GameObject sliced)
    {
        // Parçalar disable geldiyse aktifleştir
        foreach (Transform t in sliced.transform)
        {
            t.gameObject.SetActive(true);
        }

        // 1 frame bekle, Unity rigidbodyleri tanısın
        yield return null;

        Rigidbody[] bodies = sliced.GetComponentsInChildren<Rigidbody>();
        Debug.Log("🧩 Rigidbody sayısı (slice sonrası): " + bodies.Length);

        foreach (Rigidbody rb in bodies)
        {
            Vector3 forceDir = (rb.transform.position - transform.position).normalized;
            forceDir += Random.insideUnitSphere * 0.5f;
            rb.AddForce(forceDir * explosionForce, ForceMode.Impulse);
            rb.AddTorque(Random.insideUnitSphere * torqueForce, ForceMode.Impulse);
        }

        Destroy(sliced, 2f);
        Destroy(gameObject);
    }
}
