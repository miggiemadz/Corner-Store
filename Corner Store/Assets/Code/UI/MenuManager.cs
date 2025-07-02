using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;

    [Header("Inputs")]
    [SerializeField] private InputActionReference pauseInputAction;

    [Header ("Menus/UI")]
    [SerializeField] private GameObject[] listOfMenus;
    [SerializeField] private GameObject buttonInputUI;
    private GameObject currentActiveMenu;

    public GameObject CurrentActiveMenu { get => currentActiveMenu; set => currentActiveMenu = value; }

    void Start()
    {

    }

    void Update()
    {
        if (pauseInputAction.action.triggered)
        {
            listOfMenus[0].SetActive(!listOfMenus[0].activeSelf);
            buttonInputUI.SetActive(!buttonInputUI.activeSelf);
        }

        CheckActiveMenu();
    }

    private void CheckActiveMenu()
    {
        foreach (GameObject menu in listOfMenus)
        {
            if (menu.activeSelf)
            {
                CurrentActiveMenu = menu;
            }
            else
            {
                CurrentActiveMenu = null;
            }
        }
    }
}
