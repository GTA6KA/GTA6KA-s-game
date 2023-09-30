using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speedCamera;
    [SerializeField] private float _speedBorder;
    [SerializeField, Range(0f, 100f)] private float _scrollSpeed;
    [Space]
    [SerializeField] private GameObject _placeToPlayer;

    [Space]
    [SerializeField] private float _minY, _maxY;
    [SerializeField] private Vector2 _cameraLimitMapPosition;

    private Camera _camera;


    private void Start() => _camera = GetComponent<Camera>();



    private void Update()
    {
        CameraControlMethod();
    }
    private void CameraControlMethod()
    {
        Vector3 _cameraPosition = transform.position;

        if (Input.mousePosition.y >= Screen.height - _speedBorder) _cameraPosition.z += _speedCamera * Time.deltaTime;

        if (Input.mousePosition.y <= _speedBorder) _cameraPosition.z -= _speedCamera * Time.deltaTime;

        if (Input.mousePosition.x >= Screen.width - _speedBorder) _cameraPosition.x += _speedCamera * Time.deltaTime;

        if (Input.mousePosition.x <= _speedBorder) _cameraPosition.x -= _speedCamera * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F1)) _cameraPosition = _placeToPlayer.transform.position;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        _cameraPosition.y -= scroll * _scrollSpeed * 100f * Time.deltaTime;

        _cameraPosition.x = Mathf.Clamp(_cameraPosition.x, -_cameraLimitMapPosition.x, _cameraLimitMapPosition.x);
        _cameraPosition.y = Mathf.Clamp(_cameraPosition.y, _minY, _maxY);
        _cameraPosition.z = Mathf.Clamp(_cameraPosition.z, -_cameraLimitMapPosition.y, _cameraLimitMapPosition.y);

        transform.position = _cameraPosition;
    }
}
