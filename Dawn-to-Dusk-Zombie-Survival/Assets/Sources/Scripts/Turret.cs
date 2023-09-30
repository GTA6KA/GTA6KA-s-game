using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _damageBullet;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private float _timeReload;

    [Space]
    [SerializeField] private LayerMask _layerEnemy;

    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Transform _turret;

    [SerializeField] private Bullet _prefabBullet;
   

    private bool _isReaload;
    void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position, _radiusAttack, _layerEnemy))
        {
            Shot();
            FindClosestEnemy();
        }
    }

    private void Shot()
    {
        if (_isReaload == false)
        {
            StartCoroutine(Reload());
            var tempBullet = Instantiate(_prefabBullet, _shotPoint.position, Quaternion.identity);
            tempBullet.SetStats(_speedBullet, _turret.forward);
        }
        
    }

    private IEnumerator Reload()
    {
        _isReaload = true;
        yield return new WaitForSeconds(_timeReload);
        _isReaload = false;
    }

    private Transform FindClosestEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusAttack, _layerEnemy);

        float distance = Mathf.Infinity;
        Transform closestEnemy = null;

        for (int i = 0; i < colliders.Length; i++)
        {
            float curretDistance = Vector3.Distance(transform.position, colliders[i].transform.position);
            if (curretDistance < distance)
            {
                distance = curretDistance;
                _turret.transform.LookAt(colliders[i].transform);
                closestEnemy = colliders[i].transform;
            }
        }
        return closestEnemy;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusAttack);
    }
}
