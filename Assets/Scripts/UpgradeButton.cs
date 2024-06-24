using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private Text upgradeName;
    [SerializeField] private Text upgradeDesc;
    [SerializeField] private Image outline;

    [SerializeField] Sprite[] outlines;

    #region Unity Life Cycle
    private void OnDisable()
    {
        ClearData();
    }
    #endregion

    private void ClearData()
    {
        btn.onClick.RemoveAllListeners();
    }
    public void SetData(UpgradeData _data)
    {
        upgradeName.text = _data.name;
        upgradeDesc.text = _data.desc;

        switch (_data.upgradeType)
        {
            case UpgradeType.Hp:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.UpgradeStatus(10, 0); });
                    break;
                }
            case UpgradeType.Speed:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.UpgradeStatus(0, 0.5f); });
                    break;
                }
            case UpgradeType.Damage:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(10, 0, 0); });
                    break;
                }
            case UpgradeType.Delay:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(0, 10, 0); });
                    break;
                }
            case UpgradeType.Count:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(0, 0, 1); });
                    break;
                }
        }
        btn.onClick.AddListener(delegate 
        {
            UIManager.instance.HideUpgrade();
        });

        switch (_data.upgradeType)
        {
            case UpgradeType.Hp:
            case UpgradeType.Speed:
                {
                    outline.sprite = outlines[0];
                    break;
                }
            case UpgradeType.Damage:
            case UpgradeType.Delay:
                {
                    outline.sprite = outlines[1];
                    break;
                }
            case UpgradeType.Count:
                {
                    outline.sprite = outlines[2];
                    break;
                }
        }
    }
}
