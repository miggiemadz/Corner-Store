using UnityEngine;
using UnityEngine.UI;

public class MCSSManager : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] GameObject[] SSScreens;

    [Header("Universal")]
    [SerializeField] MCManager MCManager;
    [SerializeField] MCTaskbar taskbar;

    [Header("Window Transforming")]
    [SerializeField] CanvasScaler scaler;
    [SerializeField] GameObject windowedButton;
    [SerializeField] GameObject fullscreenButton;
    [SerializeField] BoxCollider2D boxCollider;

    private bool firstTimeOpen = true;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (firstTimeOpen)
        {
            foreach (var s in SSScreens)
            {
                if (SSScreens[0].Equals(s))
                {
                    s.SetActive(true);
                }

                else
                {
                    s.SetActive(false);
                }
            }

            MCManager.CurrentScreen = MCManager.Screen.SSfrontPage;
            firstTimeOpen = false;
        }

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ComputerWindowBar") && Input.GetMouseButton(0))
        {

        }
    }

    public void XButton()
    {
        firstTimeOpen = true;
        gameObject.SetActive(false);
        FullscreenButton();
    }

    public void WindowedButton()
    {
        scaler.scaleFactor = .5f;
        windowedButton.SetActive(false);
        fullscreenButton.SetActive(true);
    }

    public void FullscreenButton()
    {
        scaler.scaleFactor = 1f;
        fullscreenButton.SetActive(false);
        windowedButton.SetActive(true);
    }

    public void MinimizeButton()
    {
        foreach (GameObject tab in taskbar.MinimizedTabs)
        {
            if (!tab.activeSelf)
            {
                RawImage tabIcon = tab.GetComponent<RawImage>();
                tabIcon.texture = taskbar.Samslogo;
                tab.SetActive(true);
                break;
            }
        }

        gameObject.SetActive(false);
    }
}
