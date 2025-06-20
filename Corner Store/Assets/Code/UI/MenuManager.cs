using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;

    [Header("Inputs")]
    [SerializeField] private InputActionReference pauseInput;
    [SerializeField] private GameObject[] controllerButtonUI;
    [SerializeField] private GameObject[] inputTypes;


    [Header ("Menus/UI")]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject buttonInputUI;

    void Start()
    {

    }

    void Update()
    {
        if (pauseInput.action.triggered)
        { 
            settingsMenu.SetActive(!settingsMenu.activeSelf);
            buttonInputUI.SetActive(!buttonInputUI.activeSelf);
        }

        updateControllerInputType();
    }

    private void updateControllerInputType()
    {
        for (int i = 0;  i < controllerButtonUI.Length; i++)
        {
            for(int j = 0; i < controllerButtonUI[i].transform.childCount; j++)
            {
                if (controllerButtonUI[i].name == cameraSettings.LastInputDeviceType.ToString())
                {
                    controllerButtonUI[i].SetActive(true);
                }
                else
                {
                    controllerButtonUI[i].SetActive(false);
                }
            }
        }
    }

    private void updateGeneralInputType()
    {
        for (int i = 0; i < inputTypes.Length; i++)
        {

        }
    }
}
