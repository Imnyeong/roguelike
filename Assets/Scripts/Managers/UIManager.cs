using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Text timerText;
    [SerializeField] private Text coinText;
    [SerializeField] private Slider expSlider;
    [SerializeField] private Slider hpSlider;

    [SerializeField] private GameObject UpgradeUI;
    private const float minute = 60;
    #region Unity Life Cycle
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void FixedUpdate()
    {
        UpdateTmier();
    }
    #endregion
    public void UpdateCoin() => coinText.text = GameManager.instance.coin.ToString();
    public void UpdateTmier()
    {
        timerText.text = $"{((int)(GameManager.instance.timer / minute)).ToString("D2")}:{((int)(GameManager.instance.timer % minute)).ToString("D2")}";
    }
    public void UpdateHp() => hpSlider.value = GameManager.instance.character.GetCurrentHp();
    public void UpdateExp() => expSlider.value = GameManager.instance.character.GetCurrentExp();
    public void ShowUpgrade()
    {
        GameManager.instance.StopGame();
        UpgradeUI.SetActive(true);
    }
    public void HideUpgrade()
    {
        GameManager.instance.PlayGame();
        UpgradeUI.SetActive(false);
        GameManager.instance.character.CheckExp();
    }
}
