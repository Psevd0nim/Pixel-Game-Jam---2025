using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Player _player;

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }
}
