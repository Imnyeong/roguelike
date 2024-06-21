using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private WeaponData data;
    private Button btn;

    [SerializeField] private Image icon;
    [SerializeField] private Text desc;
    [SerializeField] private Text coin;

    #region Unity Life Cycle
    private void Awake()
    {
        Init();
    }
    private void OnEnable()
    {
        SetData();
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
        data = null;
        btn.onClick.RemoveAllListeners();
    }
    private void SetData()
    {
        btn.onClick.AddListener(OnClickButton);
    }
    private void OnClickButton()
    {
        GameManager.instance.character.weapon.UpgradeWeapon(1,1);
        UIManager.instance.HideUpgrade();
    }
}
