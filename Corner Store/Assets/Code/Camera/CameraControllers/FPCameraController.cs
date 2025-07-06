using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private GameObject playerEyes;
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private InputActionReference lookInput;
    [SerializeField] private MenuManager menuManager;

    [Header("Cinemachine Components")]
    [SerializeField] private CinemachineCamera FPPlayerCamera;
    [SerializeField] private CinemachineHardLockToTarget FPHardLockToTarget;

    void Start()
    {
        
    }

    void Update()
    {
        CameraMovement();

        // FOV
        FPPlayerCamera.Lens.FieldOfView = cameraSettings.FOV;
        gameObject.transform.forward = playerEyes.transform.forward;
    }

    private void CameraMovement()
    {
        float lookMovementX = lookInput.action.ReadValue<Vector2>().x;
        float lookMovementY = lookInput.action.ReadValue<Vector2>().y;

        Quaternion currentEyeRotation = Quaternion.Euler(playerEyes.transform.rotation.eulerAngles.x, playerEyes.transform.rotation.eulerAngles.y, 0);

        if (menuManager.CurrentActiveMenu == null)
        {
            if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.MnK)
            {
                if (Mathf.Abs(lookMovementY) > 0)
                {
                    currentEyeRotation = Quaternion.Euler(playerEyes.transform.rotation.eulerAngles.x - Mathf.Sign(lookMovementY) * cameraSettings.FPCameraSensitivityXMNK, playerEyes.transform.rotation.eulerAngles.y, 0);
                }

                if (Mathf.Abs(lookMovementX) > 0)
                {
                    currentEyeRotation = Quaternion.Euler(playerEyes.transform.rotation.eulerAngles.x, playerEyes.transform.rotation.eulerAngles.y + Mathf.Sign(lookMovementX) * cameraSettings.FPCameraSensitivityYMNK, 0);
                }
            }

            if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.Controller)
            {
                if (Mathf.Abs(lookMovementX) > 0 + cameraSettings.ControllerDeadZoneRight)
                {
                }

                if (Mathf.Abs(lookMovementY) > 0 + cameraSettings.ControllerDeadZoneRight)
                {
                }
            }
        }

        playerEyes.transform.rotation = Quaternion.RotateTowards(playerEyes.transform.rotation, currentEyeRotation, Time.deltaTime);
    }
}
