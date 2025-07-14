using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputDetector : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private InputActionReference inputDetector;

    private void OnEnable()
    {
        if (inputDetector != null && inputDetector.action != null) 
        {
            inputDetector.action.performed += OnLookPerformed;
        }
    }

    private void OnDisable()
    {
        if (inputDetector != null && inputDetector.action != null)
        {
            inputDetector.action.performed -= OnLookPerformed;
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
