using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            settingsMenu.SetActive(!settingsMenu.activeSelf);
        }
    }
}
