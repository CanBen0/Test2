using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] public float speed = 2.0f;
    [SerializeField] public float acceleration = 0.2f;
    public enum Direction { Left, Right, Up, Down };
    public Direction correctDirection = Direction.Left;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        speed += acceleration * Time.deltaTime;

    }
}
