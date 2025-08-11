using UnityEditor.Build.Pipeline.WriteTypes;
using UnityEngine;
using UnityEngine.UI;

public class MCTaskbar : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private MCManager manager;
    [SerializeField] private GameObject logoMenu;

    [Header("Tabs")]
    [SerializeField] private GameObject[] minimizedTabs;
    [SerializeField] private GameObject samsTab;

    [Header("App Icons")]
    [SerializeField] private Texture2D samslogo;

    // Tabs
    public GameObject[] MinimizedTabs { get => minimizedTabs; set => minimizedTabs = value; }

    // App Icons
    public Texture2D Samslogo { get => samslogo; set => samslogo = value; }

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

    public void OpenMinimizedTab1() 
    { 
        if (minimizedTabs[0].GetComponent<RawImage>().texture == samslogo)
        {
            samsTab.SetActive(true);
            minimizedTabs[0].GetComponent<RawImage>().texture = null;
            minimizedTabs[0].SetActive(false);
        }
    }

    public void OpenMinimizedTab2()
    {

    }

    public void OpenMinimizedTab3()
    {

    }
}
