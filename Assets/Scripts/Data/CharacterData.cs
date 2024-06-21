using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public int characterId;
    public float maxHp;
    public float speed;
    public Sprite sprite;
    public RuntimeAnimatorController animator;

    public int defaultWeapon;
}