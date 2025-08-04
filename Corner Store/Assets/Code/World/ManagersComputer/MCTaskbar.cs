using UnityEngine;

public class MCTaskbar : MonoBehaviour
{
    [SerializeField] private MCManager manager;
    [SerializeField] private GameObject logoMenu;

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void LYMELogoButton()
    {
        logoMenu.SetActive(!logoMenu.activeSelf);
    }

    public void PowerButton()
    {
        Debug.Log("Power Off");
    }
}
