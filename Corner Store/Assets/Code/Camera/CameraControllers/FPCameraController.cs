using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private GameObject playerEyes;
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private GameSettings gameSettings;
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

        Debug.Log(gameSettings.LastInputDeviceType);

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
            if (gameSettings.LastInputDeviceType == GameSettings.InputDeviceTypes.MnK)
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

            if (gameSettings.LastInputDeviceType == GameSettings.InputDeviceTypes.Controller)
            {
                if (Mathf.Abs(lookMovementX) > 0 + cameraSettings.ControllerDeadZoneRight / 10)
                {
                    lookYaw += Mathf.Sign(lookMovementX) * cameraSettings.FPCameraSensitivityXController / 10;
                }

                if (Mathf.Abs(lookMovementY) > 0 + cameraSettings.ControllerDeadZoneRight / 10)
                {
                    lookPitch -= Mathf.Sign(lookMovementY) * cameraSettings.FPCameraSensitivityYController / 10;
                }
            }
        }

        lookRotation = Quaternion.Euler(lookPitch, lookYaw, 0);

        playerEyes.transform.rotation = Quaternion.RotateTowards(playerEyes.transform.rotation, lookRotation, 200 * Time.deltaTime);
    }
}
