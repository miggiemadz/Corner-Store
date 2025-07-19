using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private GameSettings gameSettings;

    [Header("Inputs")]
    [SerializeField] private InputActionReference pauseInputAction;

    [Header("Menus/UI")]
    [SerializeField] private GameObject[] menuList;
    [SerializeField] private GameObject buttonInputUI;
    private GameObject currentActiveMenu;
    private Color selectedButtonColor;

    public GameObject CurrentActiveMenu { get => currentActiveMenu; set => currentActiveMenu = value; }
    public GameObject ButtonInputUI { get => buttonInputUI; set => buttonInputUI = value; }
    public GameObject[] MenuList { get => menuList; set => menuList = value; }
    public Color SelectedButtonColor { get => selectedButtonColor; set => selectedButtonColor = value; }

    void Start()
    {

    }

    void Update()
    {
        CheckActiveMenu();

        if (currentActiveMenu != null)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

        switch (gameSettings.LastInputDeviceType)
        {
            case GameSettings.InputDeviceTypes.MnK:
                selectedButtonColor = Color.gray;
                break;

            case GameSettings.InputDeviceTypes.Controller:
                selectedButtonColor = Color.black;
                break;
        }

        buttonInputUI.SetActive(currentActiveMenu == null && gameSettings.IsButtonInputUIActive);

        if (pauseInputAction.action.triggered)
        {
            if (menuList[0].CompareTag("Main Menu"))
            {
                if (menuList[1].activeSelf)
                {
                    menuList[1].SetActive(false);
                    menuList[0].SetActive(true);
                }
            }

            else if (menuList[0].CompareTag("Pause Menu"))
            {
                menuList[0].SetActive(!menuList[0].activeSelf);
                
                if (menuList[1].activeSelf)
                {
                    menuList[1].SetActive(false);
                }
            }
        }
    }

    private void CheckActiveMenu()
    {
        bool hasActiveScene = false;

        foreach (var menu in MenuList)
        {
            if (menu.activeSelf)
            {
                currentActiveMenu = menu;
                hasActiveScene = true;
                break;
            }
        }

        if (!hasActiveScene)
        {
            currentActiveMenu = null;
        }
    }
}
