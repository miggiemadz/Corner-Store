using System.IO.IsolatedStorage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraSettingsManager : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private Slider FOVSlider;
    [SerializeField] private TextMeshProUGUI FOVValueText;
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private Toggle shoulderCameraToggle;
    [SerializeField] private Toggle universalDeadZoneToggle;

    [Header("Mouse & Keyboard")]
    [SerializeField] private Slider MNKSensitivityXSlider;
    [SerializeField] private TextMeshProUGUI MNKSensitivityXValueText;
    [SerializeField] private Slider MNKSensitivityYSlider;
    [SerializeField] private TextMeshProUGUI MNKSensitivityYValueText;

    [Header("Controller")]
    [SerializeField] private Slider controllerSensitivityXSlider;
    [SerializeField] private TextMeshProUGUI controllerSensitivityXValueText;
    [SerializeField] private Slider controllerSensitivityYSlider;
    [SerializeField] private TextMeshProUGUI controllerSensitivityYValueText;
    [SerializeField] private Slider controllerDeadZoneLeftSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneLeftValueText;
    [SerializeField] private Slider controllerDeadZoneRightSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneRightValueText;
    [SerializeField] private Slider controllerDeadZoneUniversalSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneUniversalValueText;
    [SerializeField] private GameObject[] controllerInputTypes;
    [SerializeField] private Button controllerInputSwitchButton;

    void Start()
    {
        shoulderCameraToggle = GameObject.Find("CameraShoulderToggle").GetComponent<Toggle>();
        FOVSlider = GameObject.Find("FOVSlider").GetComponent<Slider>();
        FOVValueText = GameObject.Find("FOVValueText").GetComponent<TextMeshProUGUI>();
    }
    private void Awake()
    {
        controllerInputSwitchButton.onClick.AddListener(OnButtonClicked);
    }

    void Update()
    {
        if (controllerInputSwitchButton)

        // Camera Shoulder Toggle
        if (shoulderCameraToggle.isOn)
        {
            cameraSettings.ShoulderSide = .75f;
        }
        else
        {
            cameraSettings.ShoulderSide = -.75f;
        }

        // Universal
        cameraSettings.FOV = FOVSlider.value;
        FOVValueText.text = cameraSettings.FOV.ToString();

        // Mouse & Keyboard
        cameraSettings.CameraSensitivityXMNK = MNKSensitivityXSlider.value;
        MNKSensitivityXValueText.text = cameraSettings.CameraSensitivityXMNK.ToString();
        cameraSettings.CameraSensitivityYMNK = MNKSensitivityYSlider.value;
        MNKSensitivityYValueText.text = cameraSettings.CameraSensitivityYMNK.ToString();

        // Controller
        cameraSettings.CameraSensitivityXController = controllerSensitivityXSlider.value;
        controllerSensitivityXValueText.text = cameraSettings.CameraSensitivityXController.ToString();
        cameraSettings.CameraSensitivityYController = controllerSensitivityYSlider.value;
        controllerSensitivityYValueText.text = cameraSettings.CameraSensitivityYController.ToString();

        if (universalDeadZoneToggle.isOn)
        {
            controllerDeadZoneUniversalSlider.gameObject.SetActive(true);
            controllerDeadZoneLeftSlider.gameObject.SetActive(false);
            controllerDeadZoneRightSlider.gameObject.SetActive(false);
            cameraSettings.ControllerDeadZoneLeft = controllerDeadZoneUniversalSlider.value;
            controllerDeadZoneUniversalValueText.text = cameraSettings.ControllerDeadZoneLeft.ToString();
            cameraSettings.ControllerDeadZoneRight = controllerDeadZoneUniversalSlider.value;
            controllerDeadZoneUniversalValueText.text = cameraSettings.ControllerDeadZoneRight.ToString();
        }
        else
        {
            controllerDeadZoneUniversalSlider.gameObject.SetActive(false);
            controllerDeadZoneLeftSlider.gameObject.SetActive(true);
            controllerDeadZoneRightSlider.gameObject.SetActive(true);
            cameraSettings.ControllerDeadZoneLeft = controllerDeadZoneLeftSlider.value;
            controllerDeadZoneLeftValueText.text = cameraSettings.ControllerDeadZoneLeft.ToString();
            cameraSettings.ControllerDeadZoneRight = controllerDeadZoneRightSlider.value;
            controllerDeadZoneRightValueText.text = cameraSettings.ControllerDeadZoneRight.ToString();
        }
    }
    
    public void OnButtonClicked()
    {
        Debug.Log("Clicked");

        int currentActive = 0;

        for (int i = 0; i < controllerInputTypes.Length; i++)
        {
            if (controllerInputTypes[i].activeInHierarchy)
            {
                currentActive = i;
            }
        }

        controllerInputTypes[currentActive].SetActive(false);

        if (currentActive < 3)
        {
            currentActive++;
            controllerInputTypes[currentActive].SetActive(true);
        }
        else
        {
            currentActive = 0;
            controllerInputTypes[currentActive ].SetActive(true);
        }

        switch (currentActive)
        {
            case 0:
                cameraSettings.CurrentControllerType = CameraSettings.ControllerType.PS4;
                break;
            case 1:
                cameraSettings.CurrentControllerType = CameraSettings.ControllerType.PS5;
                break;
            case 2: 
                cameraSettings.CurrentControllerType = CameraSettings.ControllerType.XBox;
                break;
            case 3:
                cameraSettings.CurrentControllerType = CameraSettings.ControllerType.Switch;
                break;
        }

        Debug.Log(currentActive);
    }
}
