using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private const int weight_1 = 30;
    private const int weight_2 = 20;
    private const int weight_3 = 10;

    private const int minWeight = 1;
    private int totalWeight = 1;

    UpgradeData[] upgradeTable;
    [SerializeField] UpgradeButton[] upgradeButtons;

    #region Unity Life Cycle
    private void Awake()
    {
        SetTable();
    }
    private void OnEnable()
    {
        SetUpgradeButtons();
    }
    #endregion
    private void SetTable()
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        upgradeList.Add(new UpgradeData(UpgradeType.Hp, weight_1));
        upgradeList.Add(new UpgradeData(UpgradeType.Speed, weight_1));
        upgradeList.Add(new UpgradeData(UpgradeType.Damage, weight_2));
        upgradeList.Add(new UpgradeData(UpgradeType.Delay, weight_2));
        upgradeList.Add(new UpgradeData(UpgradeType.Count, weight_3));

        upgradeTable = upgradeList.ToArray();

        for(int i = 0; i < upgradeTable.Length; i++)
        {
            totalWeight += upgradeTable[i].weight;
        }
    }
    public void SetUpgradeButtons()
    {
        for(int buttonCount = 0; buttonCount < upgradeButtons.Length; buttonCount++)
        {
            int weight = Random.Range(minWeight, totalWeight);
            int currentWeight = 0;

            for (int weightCount = 0; weightCount < upgradeTable.Length; weightCount++)
            {
                currentWeight += upgradeTable[weightCount].weight;

                if (weight <= currentWeight)
                {
                    upgradeButtons[buttonCount].SetData(upgradeTable[weightCount]);
                    break;
                }
            }
        }
    }
}
