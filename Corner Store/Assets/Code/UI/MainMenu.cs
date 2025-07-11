using UnityEngine;
using static System.Net.WebRequestMethods;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;

    private string discordURL = "https://discord.gg/hYzz9EUrPc";
    private string instagramURL = "https://www.instagram.com/studioinfiniteloom/";
    private string tikTokURL = "https://www.tiktok.com/@studio_infinite_loom";
    private string xURL = "https://x.com/StudioInf_Loom";
    private string youTubeURL = "https://www.youtube.com/@StudioInfiniteLoom-yt";

    public void PlayGame()
    {
        Debug.Log("Playing game.");
    }

    public void OpenSettings()
    {
        menuManager.SettingsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenDiscord()
    {
        OpenURL(discordURL);
    }

    public void OpenInstagram()
    {
        OpenURL(instagramURL);
    }

    public void OpenTikTok()
    {
        OpenURL(tikTokURL);
    }

    public void OpenX()
    {
        OpenURL(xURL);
    }

    public void OpenYouTube()
    {
        OpenURL(youTubeURL);
    }
}
