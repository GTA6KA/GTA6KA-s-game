using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private GameObject _clickEffect;
    [SerializeField] private LayerMask _whatCanBeClicked;

    private NavMeshAgent _player;
    Camera _camera;

    bool _isClickReload;
    private void Start()
    {
        _camera = Camera.main;
        _player = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_isClickReload == true) return;

            Ray _myRay = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(_myRay, out hitInfo, 1000, _whatCanBeClicked))
            {
                _isClickReload = true;
                _clickEffect.transform.position = hitInfo.point;
                StartCoroutine(ClickEffect());
                _player.SetDestination(hitInfo.point);
            }
        }
    }
    private IEnumerator ClickEffect()
    {
        _isClickReload = true;
        _clickEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _isClickReload = false;
        _clickEffect.SetActive(false);

    }
}
