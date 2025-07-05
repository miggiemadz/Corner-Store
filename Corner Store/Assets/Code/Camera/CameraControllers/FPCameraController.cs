using Unity.Cinemachine;
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
    }

    private void CameraMovement()
    {
        float lookMovementX = lookInput.action.ReadValue<Vector2>().x;
        float lookMovementY = lookInput.action.ReadValue<Vector2>().y;

        Vector3 currentEuler = playerEyes.transform.rotation.eulerAngles;

        gameObject.transform.forward = playerEyes.gameObject.transform.forward;

        if (menuManager.CurrentActiveMenu == null)
        {
            if (Input.GetMouseButton(1) && cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.MnK)
            {
                if (Mathf.Abs(lookMovementX) > 0)
                {
                    currentEuler.x -= Mathf.Sign(lookMovementY) * cameraSettings.FPCameraSensitivityXMNK;
                }

                if (Mathf.Abs(lookMovementY) > 0)
                {
                    currentEuler.y += Mathf.Sign(lookMovementX) * cameraSettings.FPCameraSensitivityYMNK;
                }
            }

            if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.Controller)
            {
                if (Mathf.Abs(lookMovementX) > 0 + cameraSettings.ControllerDeadZoneRight)
                {
                    currentEuler.x -= Mathf.Sign(lookMovementY) * cameraSettings.FPCameraSensitivityXMNK;
                }

                if (Mathf.Abs(lookMovementY) > 0 + cameraSettings.ControllerDeadZoneRight)
                {
                    currentEuler.y += Mathf.Sign(lookMovementX) * cameraSettings.FPCameraSensitivityYMNK;
                }

            }
            playerEyes.transform.rotation = Quaternion.Euler(currentEuler);
        }
    }
}
