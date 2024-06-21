using UnityEngine;

public static class StringData
{
    // Animation
    public static string AnimationMove = "Move";
    public static string AnimationHit = "Hit";
    public static string AnimationDead = "Dead";
    // Tag
    public static string TagBackground = "Background";
    public static string TagReposRange = "RepositionRange";
    public static string TagWeapon = "Weapon";
    public static string TagMonster = "Monster";
    // Resource Path
    public static string pathWeaponData = "WeaponData";
    public static string pathCharacterData = "CharacterData";
    public static string pathMonsterData = "MonsterData";
}
public enum WeaponType
{
    Spin,
    Shoot
}