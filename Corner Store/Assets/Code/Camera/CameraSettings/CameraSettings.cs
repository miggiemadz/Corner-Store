using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettingsManager", menuName = "Scriptable Objects/CameraSettingsManager")]
public class CameraSettings : ScriptableObject
{
    public enum CameraPOVs
    {
        FirstPerson,
        ThirdPersonBehind,
        ThirdPersonFront
    }

    public enum InputDeviceTypes
    {
        ControllerInput,
        MouseInput
    }

    [Header("Universal Settings")]
    private float shoulderSide = .75f; // Component: Camera Side. Values: 1 (right), 0 (Left)
    private float fOV = 60f; // Component: Lens(Vertical FOV), Values: 60 - 90
    private CameraPOVs currentPOV;
    private InputDeviceTypes lastInputDeviceType;

    [Header("MnK Settings")]
    private float cameraSensitivityXMNK;
    private float cameraSensitivityYMNK;

    [Header("Controller Settings")]
    private float cameraSensitivityXController;
    private float cameraSensitivityYController;
    private float controllerDeadZoneLeft;
    private float controllerDeadZoneRight;

    // Universal
    public float ShoulderSide { get => shoulderSide; set => shoulderSide = value; }
    public float FOV { get => fOV; set => fOV = value; }
    public CameraPOVs CurrentPOV { get => currentPOV; set => currentPOV = value; }
    public InputDeviceTypes LastInputDeviceType { get => lastInputDeviceType; set => lastInputDeviceType = value; }


    // MnK
    public float CameraSensitivityXMNK { get => cameraSensitivityXMNK; set => cameraSensitivityXMNK = value; }
    public float CameraSensitivityYMNK { get => cameraSensitivityYMNK; set => cameraSensitivityYMNK = value; }

    // Controller
    public float CameraSensitivityXController { get => cameraSensitivityXController; set => cameraSensitivityXController = value; }
    public float CameraSensitivityYController { get => cameraSensitivityYController; set => cameraSensitivityYController = value; }
    public float ControllerDeadZoneLeft { get => controllerDeadZoneLeft; set => controllerDeadZoneLeft = value; }
    public float ControllerDeadZoneRight { get => controllerDeadZoneRight; set => controllerDeadZoneRight = value; }
}
