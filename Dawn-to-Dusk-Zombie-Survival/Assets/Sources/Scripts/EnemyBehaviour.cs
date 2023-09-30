using UnityEngine;
using UnityEngine.AI;
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _healPoints;

   
    private NavMeshAgent _enemy;
    private void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
    }


    private void FixedUpdate()
    {
        
    }

    public void TakeDamage(float damage)
    {
        _healPoints -= damage;
    }

}
