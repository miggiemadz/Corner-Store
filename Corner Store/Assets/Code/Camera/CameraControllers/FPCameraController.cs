using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private InputActionReference lookInput;
    [SerializeField] private MenuManager menuManager;

    [Header("Cinemachine Components")]
    [SerializeField] private CinemachineCamera FPPlayerCamera;
    [SerializeField] private CinemachineRotationComposer FPPlayerCameraRotationComposer;
    [SerializeField] private CinemachineCameraOffset FPCameraOffset;

    void Start()
    {
        FPPlayerCamera = gameObject.GetComponent<CinemachineCamera>();
        FPPlayerCameraRotationComposer = gameObject.GetComponent<CinemachineRotationComposer>();
        FPCameraOffset = gameObject.GetComponent<CinemachineCameraOffset>();
    }

    void Update()
    {
        CameraMovement();

        // FOV
        FPPlayerCamera.Lens.FieldOfView = cameraSettings.FOV;
    }

    private void CameraMovement()
    {
        float lookMovementX = lookInput.action.ReadValue<Vector2>().x;
        float lookMovementY = lookInput.action.ReadValue<Vector2>().y;

        if (menuManager.CurrentActiveMenu == null)
        {
            if (Input.GetMouseButton(1) && cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.MnK)
            {
                if (Mathf.Abs(lookMovementX) > 0)
                {
                    FPPlayerCameraRotationComposer.Composition.ScreenPosition.x -= (Mathf.Sign(lookMovementX) * cameraSettings.CameraSensitivityXMNK / 10);
                }

                if (Mathf.Abs(lookMovementY) > 0)
                {
                    FPPlayerCameraRotationComposer.Composition.ScreenPosition.y += (Mathf.Sign(lookMovementY) * cameraSettings.CameraSensitivityYMNK / 10);
                }
            }

            if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.Controller)
            {
                if (Mathf.Abs(lookMovementX) > 0 + cameraSettings.ControllerDeadZoneRight)
                {
                    FPPlayerCameraRotationComposer.Composition.ScreenPosition.x -= (Mathf.Sign(lookMovementX) * cameraSettings.CameraSensitivityXMNK / 10);
                }

                if (Mathf.Abs(lookMovementY) > 0 + cameraSettings.ControllerDeadZoneRight)
                {
                    FPPlayerCameraRotationComposer.Composition.ScreenPosition.y += (Mathf.Sign(lookMovementY) * cameraSettings.CameraSensitivityYMNK / 10);
                }

            }
        }
    }
}
