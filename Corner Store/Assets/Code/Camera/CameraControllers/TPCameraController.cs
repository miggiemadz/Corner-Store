using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private InputActionReference lookInput;
    [SerializeField] private MenuManager menuManager;

    [Header("Cinemachine Components")]
    [SerializeField] private CinemachineCamera TPPlayerCamera;
    [SerializeField] private CinemachineThirdPersonFollow TPPlayerCameraTPF;
    [SerializeField] private CinemachineRotationComposer TPPlayerCameraRotationComposer;
    [SerializeField] private CinemachineCameraOffset TPCameraOffset;

    void Start()
    {
        
    }

    private void Awake()
    {

    }

    void Update()
    {
        CameraMovement();

        // Camera Shoudler
        TPCameraOffset.Offset.x = cameraSettings.ShoulderSide;

        // FOV
        TPPlayerCamera.Lens.FieldOfView = cameraSettings.FOV;
    }

    private void CameraMovement()
    {
        float lookMovementX = lookInput.action.ReadValue<Vector2>().x;
        float lookMovementY = lookInput.action.ReadValue<Vector2>().y;

        if (menuManager.CurrentActiveMenu == null) 
        {
            if (Input.GetMouseButton(1) && gameSettings.LastInputDeviceType == GameSettings.InputDeviceTypes.MnK)
            {
                if (Mathf.Abs(lookMovementX) > 0)
                {
                    TPPlayerCameraRotationComposer.Composition.ScreenPosition.x -= (Mathf.Sign(lookMovementX) * cameraSettings.TPCameraSensitivityXMNK / 1000);
                }

                if (Mathf.Abs(lookMovementY) > 0)
                {
                    TPPlayerCameraRotationComposer.Composition.ScreenPosition.y += (Mathf.Sign(lookMovementY) * cameraSettings.TPCameraSensitivityYMNK / 1000);
                }
            }

            if (gameSettings.LastInputDeviceType == GameSettings.InputDeviceTypes.Controller)
            {
                if (Mathf.Abs(lookMovementX) > 0 + cameraSettings.ControllerDeadZoneRight / 10)
                {
                    TPPlayerCameraRotationComposer.Composition.ScreenPosition.x -= (Mathf.Sign(lookMovementX) * cameraSettings.TPCameraSensitivityXController / 1000);
                }

                if (Mathf.Abs(lookMovementY) > 0 + cameraSettings.ControllerDeadZoneRight / 10)
                {
                    TPPlayerCameraRotationComposer.Composition.ScreenPosition.y += (Mathf.Sign(lookMovementY) * cameraSettings.TPCameraSensitivityYController / 1000);
                }

            }
        }
    }
}
