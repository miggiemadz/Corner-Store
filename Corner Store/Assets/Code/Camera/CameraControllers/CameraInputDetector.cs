using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputDetector : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private InputActionReference lookInput;

    private void OnEnable()
    {
        if (lookInput != null && lookInput.action != null) 
        {
            lookInput.action.performed += OnLookPerformed;
        }
    }

    private void OnDisable()
    {
        if (lookInput != null && lookInput.action != null)
        {
            lookInput.action.performed -= OnLookPerformed;
        }
    }

    private void OnLookPerformed(InputAction.CallbackContext context)
    {
        var device = context.control.device;

        if (device is Mouse)
        {
            cameraSettings.LastInputDeviceType = CameraSettings.InputDeviceTypes.MnK;
        }

        if (device is Gamepad)
        {
            cameraSettings.LastInputDeviceType = CameraSettings.InputDeviceTypes.Controller;
        }
    }
}
