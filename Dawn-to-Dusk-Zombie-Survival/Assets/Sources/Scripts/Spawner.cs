using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectOfEnemies;
    [SerializeField] private List<Transform> _spawnPoints;
    private void Start() => StartCoroutine(SpawnObjcets());

    private IEnumerator SpawnObjcets()
    {

        while (true)
        {
            var objectIndex = Random.Range(0, _objectOfEnemies.Length);
            var pointIndex = Random.Range(0, _spawnPoints.Count);

            Instantiate(_objectOfEnemies[objectIndex], _spawnPoints[pointIndex].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(0.2f);
        }
    }
    
}
