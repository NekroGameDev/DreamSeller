using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speedFollow;
    [SerializeField] private Vector3 offset;

    [SerializeField] private Camera sceneCamera;

    #region [PublicVars]

    public Camera GetCurrentCamera => currentCamera;

    #endregion

    #region [PrivateVars]

    private Camera _camera;
    private Camera currentCamera;

    private bool isCameraSwap = false;

    #endregion

    private void Start()
    {
        _camera = Camera.main;
        currentCamera = _camera;

        offset.z = _camera.transform.position.z;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (sceneCamera == null)
            {
                Debug.LogWarning("Set scene camera");
                return;
            }

            isCameraSwap = !isCameraSwap;

            _camera.gameObject.SetActive(!isCameraSwap);
            sceneCamera.gameObject.SetActive(isCameraSwap);

            currentCamera = isCameraSwap ? sceneCamera : _camera;
        }
    }

    private void FixedUpdate()
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, transform.position + offset, speedFollow * Time.fixedDeltaTime);        
    }
}
