using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Vector2 _moveInput;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = Time.deltaTime * moveSpeed * _moveInput;
        transform.position += delta;
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
