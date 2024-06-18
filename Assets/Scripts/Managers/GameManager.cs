using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character character;
    public ObejctPool objectPool;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
