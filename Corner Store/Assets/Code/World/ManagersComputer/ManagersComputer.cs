using UnityEngine;

public class ManagersComputer : MonoBehaviour
{
    [SerializeField] private MCManager manager;

    void Start()
    {
        SetVirusStats();
        SetDiscountCodeStats();
    }

    private void OnEnable()
    {
        manager.CurrentScreen = MCManager.Screen.mainLock;
    }

    void Update()
    {
        VirusSpawner();
        DiscountCodeSpawner();
    }

    private void OnApplicationQuit()
    {

    }

    private void VirusSpawner()
    {
        if (manager.CurrentScreen != MCManager.Screen.mainLock && manager.CurrentComputerType != MCManager.ComputerType.Quantum)
        {
            if (manager.VirusSpawnTimeCountdown < 0)
            {
                manager.VirusSpawnCheck = Random.Range(0, 100);

                if (manager.VirusSpawnCheck < manager.VirusSpawnChance)
                {

                }

                manager.VirusSpawnTimeCountdown = manager.VirusSpawnTime;
            }

            manager.VirusSpawnTimeCountdown -= Time.deltaTime * 100;
        }
    }

    private void DiscountCodeSpawner()
    {
        if (manager.CurrentScreen != MCManager.Screen.mainLock)
        {
            if (manager.DiscountCodeSpawnTimeCountdown < 0)
            {
                manager.DiscountCodeSpawnCheck = Random.Range(0, 100);

                if (manager.DiscountCodeSpawnCheck < manager.DiscountCodeSpawnChance)
                {

                }

                manager.DiscountCodeSpawnTimeCountdown = manager.DiscountCodeSpawnTime;
            }

            manager.DiscountCodeSpawnTimeCountdown -= Time.deltaTime * 100;
        }
    }

    private void SetVirusStats()
    {
        switch (manager.CurrentComputerType)
        {
            case MCManager.ComputerType.HomePC:
                manager.VirusSpawnTime = 180f;
                manager.VirusSpawnChance = 50f;
                break;
            case MCManager.ComputerType.OfficeMax:
                manager.VirusSpawnTime = 300f;
                manager.VirusSpawnChance = 35f;
                break;
            case MCManager.ComputerType.SleekPro:
                manager.VirusSpawnTime = 420f;
                manager.VirusSpawnChance = 15f;
                break;
        }

        manager.VirusSpawnTimeCountdown = manager.VirusSpawnTime;
    }

    private void SetDiscountCodeStats()
    {
        switch (manager.CurrentComputerType)
        {
            case MCManager.ComputerType.HomePC:
                manager.DiscountCodeSpawnTime = 600f;
                manager.DiscountCodeSpawnChance = 10f;
                break;
            case MCManager.ComputerType.OfficeMax:
                manager.DiscountCodeSpawnTime = 540f;
                manager.DiscountCodeSpawnChance = 20f;
                break;
            case MCManager.ComputerType.SleekPro:
                manager.DiscountCodeSpawnTime = 360f;
                manager.DiscountCodeSpawnChance = 30f;
                break;
            case MCManager.ComputerType.Quantum:
                manager.DiscountCodeSpawnTime = 240f;
                manager.DiscountCodeSpawnChance = 40f;
                break;
        }

        manager.DiscountCodeSpawnTimeCountdown = manager.DiscountCodeSpawnTime;
    }
}
