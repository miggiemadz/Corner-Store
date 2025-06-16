using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private InputActionReference cameraInput;

    [Header("Cinemachine Components")]
    [SerializeField] private CinemachineCamera FPPlayerCamera;
    [SerializeField] private CinemachineThirdPersonFollow FPPlayerCameraTPF;
    [SerializeField] private CinemachineRotationComposer FPPlayerCameraRotationComposer;
    [SerializeField] private CinemachineCameraOffset FPCameraOffset;

    void Start()
    {
        FPPlayerCamera = gameObject.GetComponent<CinemachineCamera>();
        FPPlayerCameraTPF = gameObject.GetComponent<CinemachineThirdPersonFollow>();
        FPPlayerCameraRotationComposer = gameObject.GetComponent<CinemachineRotationComposer>();
        FPCameraOffset = gameObject.GetComponent<CinemachineCameraOffset>();
    }

    void Update()
    {
        
    }
}
