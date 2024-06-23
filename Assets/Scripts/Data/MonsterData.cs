using UnityEngine;

[CreateAssetMenu]
public class MonsterData : ScriptableObject
{
    public float maxHp;
    public float speed;
    public int damage;

    public int rewardExp;
    public int rewardCoin;

    public Sprite sprite;
    public RuntimeAnimatorController animator;
}
