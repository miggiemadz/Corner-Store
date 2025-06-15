using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPBCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private InputActionReference cameraInput;

    [Header("Cinemachine Components")]
    [SerializeField] private CinemachineCamera TPBPlayerCamera;
    [SerializeField] private CinemachineThirdPersonFollow TPBPlayerCameraTPF;
    [SerializeField] private CinemachineRotationComposer TPBPlayerCameraRotationComposer;
    [SerializeField] private CinemachineCameraOffset TPBCameraOffset;

    void Start()
    {
        TPBPlayerCamera = gameObject.GetComponent<CinemachineCamera>();
        TPBPlayerCameraTPF = gameObject.GetComponent<CinemachineThirdPersonFollow>();
        TPBPlayerCameraRotationComposer = gameObject.GetComponent<CinemachineRotationComposer>();
        TPBCameraOffset = gameObject.GetComponent<CinemachineCameraOffset>();
    }

    private void Awake()
    {

    }

    void Update()
    {
        MNKCameraMovement();

        // Camera Shoudler
        TPBCameraOffset.Offset.x = cameraSettings.ShoulderSide;

        // FOV
        TPBPlayerCamera.Lens.FieldOfView = cameraSettings.FOV;
    }

    private void MNKCameraMovement()
    {
        float mouseMovementX = cameraInput.action.ReadValue<Vector2>().x;
        float mouseMovementY = cameraInput.action.ReadValue<Vector2>().y;

        Debug.Log(mouseMovementX + " " + mouseMovementY);

        if (Input.GetMouseButton(1) || Gamepad.all.Count > 0) 
        { 
            if (Mathf.Abs(mouseMovementX) > 4)
            {
                Debug.Log("Moving camera right");
                TPBPlayerCameraRotationComposer.Composition.ScreenPosition.x -= (Mathf.Sign(mouseMovementX) * cameraSettings.CameraSensitivityXMNK / 10);
            }

            if (Mathf.Abs(mouseMovementY) > 4)
            {
                TPBPlayerCameraRotationComposer.Composition.ScreenPosition.y += (Mathf.Sign(mouseMovementY) * cameraSettings.CameraSensitivityYMNK / 10);
            }
        }
    }
}
