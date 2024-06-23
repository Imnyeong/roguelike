using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private Button btn;

    [SerializeField] private Image icon;
    [SerializeField] private Text desc;
    [SerializeField] private Text coin;

    #region Unity Life Cycle
    private void Awake()
    {
        Init();
    }
    private void OnDisable()
    {
        ClearData();
    }
    #endregion

    private void Init()
    {
        btn = GetComponent<Button>();
    }
    private void ClearData()
    {
        btn.onClick.RemoveAllListeners();
    }
    public void SetData(UpgradeData _data)
    {
        switch (_data.upgradeType)
        {
            case UpgradeType.Hp:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.UpgradeStatus(1, 0); });
                    desc.text = StringData.Hp;
                    break;
                }
            case UpgradeType.Speed:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.UpgradeStatus(0, 1); });
                    desc.text = StringData.Speed;
                    break;
                }
            case UpgradeType.Damage:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(1, 0, 0); });
                    desc.text = StringData.Damaga;
                    break;
                }
            case UpgradeType.Delay:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(0, 1, 0); });
                    desc.text = StringData.Delay;
                    break;
                }
            case UpgradeType.Count:
                {
                    btn.onClick.AddListener(delegate { GameManager.instance.character.weapon.UpgradeWeapon(0, 0, 1); });
                    desc.text = StringData.Count;
                    break;
                }
        }
        btn.onClick.AddListener(delegate 
        {
            UIManager.instance.HideUpgrade();
        });
    }
}
