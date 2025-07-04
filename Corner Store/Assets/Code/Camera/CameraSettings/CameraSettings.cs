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
        Controller,
        MnK
    }

    public enum ControllerType
    {
        PS4,
        PS5,
        XBox,
        Switch
    }

    [Header("Universal Settings")]
    private float shoulderSide = .75f; 
    private float fOV = 60f;
    private bool isSettingsActive;
    private CameraPOVs currentPOV;
    private InputDeviceTypes lastInputDeviceType;
    private ControllerType currentControllerType;

    [Header("MnK Settings")]
    private float cameraSensitivityXMNK = 0.1f;
    private float cameraSensitivityYMNK = 0.1f;

    [Header("Controller Settings")]
    private float cameraSensitivityXController = 0.1f;
    private float cameraSensitivityYController = 0.1f;
    private float controllerDeadZoneLeft = 0.1f;
    private float controllerDeadZoneRight = 0.1f;

    // Universal
    public float ShoulderSide { get => shoulderSide; set => shoulderSide = value; }
    public float FOV { get => fOV; set => fOV = value; }
    public CameraPOVs CurrentPOV { get => currentPOV; set => currentPOV = value; }
    public InputDeviceTypes LastInputDeviceType { get => lastInputDeviceType; set => lastInputDeviceType = value; }
    public ControllerType CurrentControllerType { get => currentControllerType; set => currentControllerType = value; }
    public bool IsSettingsActive { get => isSettingsActive; set => isSettingsActive = value; }

    // MnK
    public float CameraSensitivityXMNK { get => cameraSensitivityXMNK; set => cameraSensitivityXMNK = value; }
    public float CameraSensitivityYMNK { get => cameraSensitivityYMNK; set => cameraSensitivityYMNK = value; }

    // Controller
    public float CameraSensitivityXController { get => cameraSensitivityXController; set => cameraSensitivityXController = value; }
    public float CameraSensitivityYController { get => cameraSensitivityYController; set => cameraSensitivityYController = value; }
    public float ControllerDeadZoneLeft { get => controllerDeadZoneLeft; set => controllerDeadZoneLeft = value; }
    public float ControllerDeadZoneRight { get => controllerDeadZoneRight; set => controllerDeadZoneRight = value; }
}
