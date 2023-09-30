using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;
    public void SetStats(float speed, Vector3 direction)
    {
        _speed = speed;
        _direction = direction;
    }
    private void FixedUpdate()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        Destroy(gameObject, 3f);
    }
}
