using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;

    [Header("Inputs")]
    [SerializeField] private InputActionReference pauseInputAction;

    [Header("Menus/UI")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject[] menuList;
    [SerializeField] private GameObject buttonInputUI;
    private GameObject currentActiveMenu;

    public GameObject CurrentActiveMenu { get => currentActiveMenu; set => currentActiveMenu = value; }
    public GameObject SettingsMenu { get => settingsMenu; set => settingsMenu = value; }

    void Start()
    {
        menuList = new GameObject[3];
        menuList [0] = mainMenu;
        menuList [1] = pauseMenu;
        menuList [2] = SettingsMenu;
    }

    void Update()
    {
        CheckActiveMenu();

        if (currentActiveMenu != null)
        {
            buttonInputUI.SetActive(false);
        }

        if (pauseInputAction.action.triggered)
        {
            
        }
    }

    private void CheckActiveMenu()
    {
        bool hasActiveScene = false;

        foreach (var menu in menuList)
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
