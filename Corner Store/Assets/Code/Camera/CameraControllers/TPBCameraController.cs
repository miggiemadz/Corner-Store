using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPBCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private InputActionReference lookInput;

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
        CameraMovement();

        // Camera Shoudler
        TPBCameraOffset.Offset.x = cameraSettings.ShoulderSide;

        // FOV
        TPBPlayerCamera.Lens.FieldOfView = cameraSettings.FOV;
    }

    private void CameraMovement()
    {
        float lookMovementX = lookInput.action.ReadValue<Vector2>().x;
        float lookMovementY = lookInput.action.ReadValue<Vector2>().y;

        if (Input.GetMouseButton(1) && cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.MouseInput)
        {
           if (Mathf.Abs(lookMovementX) > 0)
           {
               TPBPlayerCameraRotationComposer.Composition.ScreenPosition.x -= (Mathf.Sign(lookMovementX) * cameraSettings.CameraSensitivityXMNK / 10);
           }

           if (Mathf.Abs(lookMovementY) > 0)
           {
               TPBPlayerCameraRotationComposer.Composition.ScreenPosition.y += (Mathf.Sign(lookMovementY) * cameraSettings.CameraSensitivityYMNK / 10);
           }
        }
            
        if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.ControllerInput)
        {
           if (Mathf.Abs(lookMovementX) > 0 + cameraSettings.ControllerDeadZoneRight)
           {
               TPBPlayerCameraRotationComposer.Composition.ScreenPosition.x -= (Mathf.Sign(lookMovementX) * cameraSettings.CameraSensitivityXMNK / 10);
           }

           if (Mathf.Abs(lookMovementY) > 0 + cameraSettings.ControllerDeadZoneRight)
           {
               TPBPlayerCameraRotationComposer.Composition.ScreenPosition.y += (Mathf.Sign(lookMovementY) * cameraSettings.CameraSensitivityYMNK / 10);
           }
        
        }
    }
}
