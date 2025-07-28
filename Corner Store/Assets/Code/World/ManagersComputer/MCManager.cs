using UnityEngine;

[CreateAssetMenu(fileName = "MCManager", menuName = "Scriptable Objects/MCManager")]
public class MCManager : ScriptableObject
{
    public enum Screen
    {
        mainLock,
        mainDesktop,
        SSfrontPage,
        SSgeneralGoods,
        SScoldCuisine,
        SSfreshFrozen,
        SSmembership,
        SSorderHistory,
        SShelp,
        SScart,
        SLenergy,
        SLfinances,
        SLreviews
    }

    public enum ComputerType
    {
        HomePC,
        OfficeMax,
        SleekPro,
        Quantum
    }

    [Header("Viruses")]
    private float virusSpawnChance = 0;
    private float virusSpawnTime = 0;
    private float virusSpawnTimeCountdown = 0;
    private float virusSpawnCheck = 0;

    [Header("Truck Ad")]
    private bool canSpawnTruckAd = false;

    [Header("Discount Codes")]
    private float discountCodeSpawnChance = 0;
    private float discountCodeSpawnTime = 0;
    private float discountCodeSpawnTimeCountdown = 0;
    private float discountCodeSpawnCheck = 0;

    [Header("BlackMartAd")]
    private bool canSpawnBlackMartAd = false;

    private Screen currentScreen;
    private ComputerType currentComputerType = ComputerType.HomePC;

    // Main
    public Screen CurrentScreen { get => currentScreen; set => currentScreen = value; }
    public ComputerType CurrentComputerType { get => currentComputerType; set => currentComputerType = value; }

    // Virus
    public float VirusSpawnChance { get => virusSpawnChance; set => virusSpawnChance = value; }
    public float VirusSpawnTime { get => virusSpawnTime; set => virusSpawnTime = value; }
    public float VirusSpawnTimeCountdown { get => virusSpawnTimeCountdown; set => virusSpawnTimeCountdown = value; }
    public float VirusSpawnCheck { get => virusSpawnCheck; set => virusSpawnCheck = value; }

    // Truck Ad
    public bool CanSpawnTruckAd { get => canSpawnTruckAd; set => canSpawnTruckAd = value; }

    // Discount Codes
    public float DiscountCodeSpawnChance { get => discountCodeSpawnChance; set => discountCodeSpawnChance = value; }
    public float DiscountCodeSpawnTime { get => discountCodeSpawnTime; set => discountCodeSpawnTime = value; }
    public float DiscountCodeSpawnTimeCountdown { get => discountCodeSpawnTimeCountdown; set => discountCodeSpawnTimeCountdown = value; }
    public float DiscountCodeSpawnCheck { get => discountCodeSpawnCheck; set => discountCodeSpawnCheck = value; }

    // Black Mart Ad
    public bool CanSpawnBlackMartAd { get => canSpawnBlackMartAd; set => canSpawnBlackMartAd = value; }

}