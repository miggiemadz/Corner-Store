using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    void Start()
    {
        settingsMenu = GameObject.Find("SettingsMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            settingsMenu.SetActive(!settingsMenu.activeSelf);
        }
    }
}
