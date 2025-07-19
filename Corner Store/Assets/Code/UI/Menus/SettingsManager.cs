using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private Slider FOVSlider;
    [SerializeField] private TextMeshProUGUI FOVValueText;
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private Toggle shoulderCameraToggle;
    [SerializeField] private Toggle universalDeadZoneToggle;
    [SerializeField] private Toggle buttonInputTutorialToggle;

    [Header("Mouse & Keyboard")]
    [SerializeField] private Slider TPMNKSensitivityXSlider;
    [SerializeField] private TextMeshProUGUI TPMNKSensitivityXValueText;
    [SerializeField] private Slider TPMNKSensitivityYSlider;
    [SerializeField] private TextMeshProUGUI TPMNKSensitivityYValueText;
    [SerializeField] private Slider FPMNKSensitivityXSlider;
    [SerializeField] private TextMeshProUGUI FPMNKSensitivityXValueText;
    [SerializeField] private Slider FPMNKSensitivityYSlider;
    [SerializeField] private TextMeshProUGUI FPMNKSensitivityYValueText;

    [Header("Controller")]
    [SerializeField] private Slider TPControllerSensitivityXSlider;
    [SerializeField] private TextMeshProUGUI TPControllerSensitivityXValueText;
    [SerializeField] private Slider TPControllerSensitivityYSlider;
    [SerializeField] private TextMeshProUGUI TPControllerSensitivityYValueText;
    [SerializeField] private Slider FPControllerSensitivityXSlider;
    [SerializeField] private TextMeshProUGUI FPControllerSensitivityXValueText;
    [SerializeField] private Slider FPControllerSensitivityYSlider;
    [SerializeField] private TextMeshProUGUI FPControllerSensitivityYValueText;
    [SerializeField] private Slider controllerDeadZoneLeftSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneLeftValueText;
    [SerializeField] private Slider controllerDeadZoneRightSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneRightValueText;
    [SerializeField] private Slider controllerDeadZoneUniversalSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneUniversalValueText;
    [SerializeField] private GameObject[] controllerInputTypes;
    [SerializeField] private Button controllerInputSwitchButton;

    [Header("Support")]
    [SerializeField] private GameObject[] itemsList;
    [SerializeField] private InputActionReference UINavigateInput;
    [SerializeField] private InputActionReference UISelectInput;
    [SerializeField] private InputActionReference UIScrollInput;
    [SerializeField] private Scrollbar scrollBar;
    private int buttonPointer;
    private bool navButtonPressed;

    public Toggle ButtonInputTutorialToggle { get => buttonInputTutorialToggle; set => buttonInputTutorialToggle = value; }

    void Start()
    {
        shoulderCameraToggle = GameObject.Find("CameraShoulderToggle").GetComponent<Toggle>();
        FOVSlider = GameObject.Find("FOVSlider").GetComponent<Slider>();
        FOVValueText = GameObject.Find("FOVValueText").GetComponent<TextMeshProUGUI>();

        buttonPointer = -1;
        navButtonPressed = false;
    }
    private void Awake()
    {
        controllerInputSwitchButton.onClick.AddListener(OnControllerInputButtonClicked);
    }

    void Update()
    {
        ControllerNavigation();
        HighlightButtons();
        SelectButtons();

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
        gameSettings.IsButtonInputUIActive = buttonInputTutorialToggle.isOn;

        // Mouse & Keyboard
        cameraSettings.TPCameraSensitivityXMNK = TPMNKSensitivityXSlider.value;
        TPMNKSensitivityXValueText.text = cameraSettings.TPCameraSensitivityXMNK.ToString();
        cameraSettings.TPCameraSensitivityYMNK = TPMNKSensitivityYSlider.value;
        TPMNKSensitivityYValueText.text = cameraSettings.TPCameraSensitivityYMNK.ToString();
        cameraSettings.FPCameraSensitivityXMNK = FPMNKSensitivityXSlider.value;
        FPMNKSensitivityXValueText.text = cameraSettings.FPCameraSensitivityXMNK.ToString();
        cameraSettings.FPCameraSensitivityYMNK = FPMNKSensitivityYSlider.value;
        FPMNKSensitivityYValueText.text = cameraSettings.FPCameraSensitivityYMNK.ToString();

        // Controller
        cameraSettings.TPCameraSensitivityXController = TPControllerSensitivityXSlider.value;
        TPControllerSensitivityXValueText.text = cameraSettings.TPCameraSensitivityXController.ToString();
        cameraSettings.TPCameraSensitivityYController = TPControllerSensitivityYSlider.value;
        TPControllerSensitivityYValueText.text = cameraSettings.TPCameraSensitivityYController.ToString();
        cameraSettings.FPCameraSensitivityXController = FPControllerSensitivityXSlider.value;
        FPControllerSensitivityXValueText.text = cameraSettings.FPCameraSensitivityXController.ToString();
        cameraSettings.FPCameraSensitivityYController = FPControllerSensitivityYSlider.value;
        FPControllerSensitivityYValueText.text = cameraSettings.FPCameraSensitivityYController.ToString();

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
    
    public void OnControllerInputButtonClicked()
    {
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
                gameSettings.CurrentControllerType = GameSettings.ControllerType.PS4;
                break;
            case 1:
                gameSettings.CurrentControllerType = GameSettings.ControllerType.PS5;
                break;
            case 2: 
                gameSettings.CurrentControllerType = GameSettings.ControllerType.XBox;
                break;
            case 3:
                gameSettings.CurrentControllerType = GameSettings.ControllerType.Switch;
                break;
        }
    }

    private void ControllerNavigation()
    {
        Vector2 dPadValue = UINavigateInput.action.ReadValue<Vector2>();
        Vector2 scrollValue = UIScrollInput.action.ReadValue<Vector2>();

        if (dPadValue == Vector2.zero && navButtonPressed)
        {
            navButtonPressed = false;
        }

        if (gameSettings.LastInputDeviceType == GameSettings.InputDeviceTypes.Controller && !navButtonPressed)
        {
            if ((dPadValue.y > 0.5f || dPadValue.y < -0.5f) && buttonPointer == -1)
            {
                buttonPointer = 0;
                navButtonPressed = true;
            }

            else if (dPadValue.y < -0.5f)
            {
                if (buttonPointer == itemsList.Length - 1)
                {
                    buttonPointer = 0;
                }

                else if (buttonPointer == 11 && !universalDeadZoneToggle.isOn)
                {
                    buttonPointer += 2;
                }

                else if (buttonPointer == 12)
                {
                    buttonPointer += 3;
                }

                else
                {
                    buttonPointer++;
                }
                navButtonPressed = true;
            }

            else if (dPadValue.y > 0.5f)
            {
                if (buttonPointer == 0)
                {
                    buttonPointer = itemsList.Length - 1;
                }

                else if (buttonPointer == 13 && !universalDeadZoneToggle.isOn)
                {
                    buttonPointer -= 2;
                }

                else if (buttonPointer == 15 && universalDeadZoneToggle.isOn)
                {
                    buttonPointer -= 3;
                }

                else
                {
                    buttonPointer--;
                }
                navButtonPressed = true;
            }

            if (scrollValue.y < 0 && scrollBar.value > 0)
            {
                scrollBar.value -= .002f;
            }

            if (scrollValue.y > 0 && scrollBar.value < 1)
            {
                scrollBar.value += .002f;
            }
            
        }
    }

    private void HighlightButtons()
    {
        if (buttonPointer > -1)
        {
            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(itemsList[buttonPointer]);

            if (buttonPointer == 15)
            {
                itemsList[buttonPointer].GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            }

            if (buttonPointer != 15)
            {
                itemsList[15].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            }
        }
    }

    private void SelectButtons()
    {
        
    }
}
