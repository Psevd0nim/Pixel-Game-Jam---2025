using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private Rigidbody2D _rb;

    private void Update()
    {
        _rb.MovePosition(transform.position + direction);
    }
}
