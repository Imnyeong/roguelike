using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int characterId;

    public Character character;
    public ObejctPool objectPool;

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
        PlayGame();
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
        timer += Time.fixedDeltaTime;
    }
}