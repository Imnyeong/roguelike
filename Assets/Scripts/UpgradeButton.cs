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
        outline.sprite = outlines[_data.tier];

        switch (_data.upgradeType)
        {
            case UpgradeType.Hp:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.UpgradeStatus(_data.value, 0); });
                    break;
                }
            case UpgradeType.Speed:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.UpgradeStatus(0, _data.value); });
                    break;
                }
            case UpgradeType.Damage:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(_data.value, 0, 0); });
                    break;
                }
            case UpgradeType.Delay:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(0, _data.value, 0); });
                    break;
                }
            case UpgradeType.Count:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(0, 0, (int)_data.value); });
                    break;
                }
        }
        btn.onClick.AddListener(delegate 
        {
            UIManager.instance.HideUpgrade();
        });
    }
}
