using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPFCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private InputActionReference lookInput;
    [SerializeField] private MenuManager menuManager;

    [Header("Cinemachine Components")]
    [SerializeField] private CinemachineCamera TPFPlayerCamera;
    [SerializeField] private CinemachineThirdPersonFollow TPFPlayerCameraTPF;
    [SerializeField] private CinemachineRotationComposer TPFPlayerCameraRotationComposer;
    [SerializeField] private CinemachineCameraOffset TPFCameraOffset;

    void Start()
    {
        TPFPlayerCamera = gameObject.GetComponent<CinemachineCamera>();
        TPFPlayerCameraTPF = gameObject.GetComponent<CinemachineThirdPersonFollow>();
        TPFPlayerCameraRotationComposer = gameObject.GetComponent<CinemachineRotationComposer>();
        TPFCameraOffset = gameObject.GetComponent<CinemachineCameraOffset>();
    }

    void Update()
    {
        
    }
}
