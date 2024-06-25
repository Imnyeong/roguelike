using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int characterId;
    public int stage { get; private set; } = 1;
    public int needCount { get; private set; } = 10;
    public int killCount { get; private set; } = 0;
    public float maxTime = 300.0f;
    public Character character;
    public ObejctPool objectPool;
    public MonsterSpawner monsterSpawner;
    public StageManager stageManager;

    public int coin { get; private set; }
    public float timer { get; private set; }

    #region Unity Life Cycle
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        character.SetData(characterId);
        SetGame();
    }
    private void FixedUpdate()
    {
        Timer();
    }
    #endregion
    #region Coin
    public void GetCoin(int _value)
    {
        coin += _value;
        UIManager.instance.UpdateCoin();
    }
    #endregion
    public void SetGame()
    {
        timer = maxTime;
    }
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
    }
    public void StopGame()
    {
        Time.timeScale = 0.0f;
    }
    public void Timer()
    {
        timer -= Time.fixedDeltaTime;

        if(timer == 0)
        {
            StopGame();
        }
    }
    public void KillMonster()
    {
        killCount++;

        if(killCount > stage * needCount)
        {
            killCount = 0;
            stage++;
            monsterSpawner.SetMonster();
            stageManager.SetStage();
        }
        UIManager.instance.UpdateStage();
    }
}