using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speedFollow;
    [SerializeField] private Vector3 offset;

    [SerializeField] private Camera sceneCamera;

    private Camera _camera;

    private bool isCameraSwap = false;

    private void Start()
    {
        _camera = Camera.main;

        offset = _camera.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (sceneCamera == null)
            {
                return;
            }

            isCameraSwap = !isCameraSwap;

            _camera.gameObject.SetActive(!isCameraSwap);
            sceneCamera.gameObject.SetActive(isCameraSwap);
        }
    }

    private void FixedUpdate()
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, transform.position + offset, speedFollow * Time.fixedDeltaTime);        
    }
}
