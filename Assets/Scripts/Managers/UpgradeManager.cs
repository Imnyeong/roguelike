using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private const int minWeight = 1;
    private int totalWeight = 1;

    [SerializeField] private UpgradeData[] upgradeTable;
    [SerializeField] private UpgradeButton[] upgradeButtons;

    #region Unity Life Cycle
    private void Awake()
    {
        SetWeight();
    }
    private void OnEnable()
    {
        SetUpgradeButtons();
    }
    #endregion
    private void SetWeight()
    {
        for (int i = 0; i < upgradeTable.Length; i++)
        {
            totalWeight += upgradeTable[i].weight;
        }
    }
    public void SetUpgradeButtons()
    {
        for (int buttonCount = 0; buttonCount < upgradeButtons.Length; buttonCount++)
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
