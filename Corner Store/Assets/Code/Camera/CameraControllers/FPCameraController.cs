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
    private float lookPitch;
    private float lookYaw;
    private Quaternion lookRotation;

    void Start()
    {
        lookRotation = Quaternion.Euler(playerEyes.transform.rotation.eulerAngles.x, playerEyes.transform.rotation.eulerAngles.y, 0);

        lookPitch = lookRotation.eulerAngles.x;
        lookYaw = lookRotation.eulerAngles.y;
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

        if (menuManager.CurrentActiveMenu == null)
        {
            if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.MnK)
            {
                if (Mathf.Abs(lookMovementY) > 0)
                {
                    lookPitch -= Mathf.Sign(lookMovementY) * cameraSettings.FPCameraSensitivityYMNK / 10;
                }

                if (Mathf.Abs(lookMovementX) > 0)
                {
                    lookYaw += Mathf.Sign(lookMovementX) * cameraSettings.FPCameraSensitivityXMNK / 10;
                }
            }

            if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.Controller)
            {
                if (Mathf.Abs(lookMovementX) > 0 + cameraSettings.ControllerDeadZoneRight)
                {
                    lookYaw += Mathf.Sign(lookMovementX) * cameraSettings.FPCameraSensitivityXMNK / 10;
                }

                if (Mathf.Abs(lookMovementY) > 0 + cameraSettings.ControllerDeadZoneRight)
                {
                    lookPitch -= Mathf.Sign(lookMovementY) * cameraSettings.FPCameraSensitivityYMNK / 10;
                }
            }
        }
        lookRotation = Quaternion.Euler(lookPitch, lookYaw, 0);

        playerEyes.transform.rotation = Quaternion.RotateTowards(playerEyes.transform.rotation, lookRotation, 200 * Time.deltaTime);
    }
}
