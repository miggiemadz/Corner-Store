using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputDetector : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private GameSettings gameSettings;
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
            gameSettings.LastInputDeviceType = GameSettings.InputDeviceTypes.MnK;
        }

        if (device is Gamepad)
        {
            gameSettings.LastInputDeviceType = GameSettings.InputDeviceTypes.Controller;
        }
    }
}
