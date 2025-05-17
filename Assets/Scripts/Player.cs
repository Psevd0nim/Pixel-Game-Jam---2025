using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _speed;

    private void Update()
    {
        _rb.MovePosition(transform.position + direction * Time.deltaTime * _speed);
        _playerAnimator.SetFloat("Speed", Mathf.Abs(direction.x) + Mathf.Abs(direction.y));


        bool leftMove = direction.x < 0;
        bool rightMove = direction.x > 0;

        if (leftMove)
            _sprite.flipX = leftMove;
        if (rightMove)
            _sprite.flipX = !rightMove;

    }
}
