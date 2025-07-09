using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public enum InputDeviceTypes
    {
        MnK,
        Controller
    }

    public enum ControllerType
    {
        PS4,
        PS5,
        XBox,
        Switch
    }

    private InputDeviceTypes lastInputDeviceType;
    private ControllerType currentControllerType;
    private bool isSettingsActive;

    public InputDeviceTypes LastInputDeviceType { get => lastInputDeviceType; set => lastInputDeviceType = value; }
    public ControllerType CurrentControllerType { get => currentControllerType; set => currentControllerType = value; }
    public bool IsSettingsActive { get => isSettingsActive; set => isSettingsActive = value; }
}
