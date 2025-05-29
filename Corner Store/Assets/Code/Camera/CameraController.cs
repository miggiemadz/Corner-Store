using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineThirdPersonFollow playerCameraTPF;
    [SerializeField] private CinemachineRotationComposer playerCameraRotationComposer;

    void Start()
    {
        playerCamera = gameObject.GetComponent<CinemachineCamera>();
        playerCameraTPF = gameObject.GetComponent<CinemachineThirdPersonFollow>();
        playerCameraRotationComposer = gameObject.GetComponent<CinemachineRotationComposer>();
    }

    private void Awake()
    {

    }

    void Update()
    {
        // Camera Shoudler
        playerCameraTPF.CameraSide = cameraSettings.ShoulderSide;

        // FOV
        playerCamera.Lens.FieldOfView = cameraSettings.FOV;

        Debug.Log(cameraSettings.FOV);
    }
}
