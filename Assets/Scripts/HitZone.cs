using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public static List<CubeBehavior> cubesInZone = new List<CubeBehavior>();
    private void Update()
    {
        foreach (var cube in cubesInZone)
        {
            if (cube != null)
                Debug.DrawLine(transform.position, cube.transform.position, Color.green);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeBehavior cube = other.GetComponent<CubeBehavior>();
        if (cube != null && !cubesInZone.Contains(cube))
        {
            cubesInZone.Add(cube);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Giren obje: " + other.name);
        
        CubeBehavior cube = other.GetComponent<CubeBehavior>();
        if (cube != null && cubesInZone.Contains(cube))
        {
            cubesInZone.Remove(cube);
        }
    }
    
}
