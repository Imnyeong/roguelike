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
    // Status
    public static string Hp = "체력 강화";
    public static string Speed = "이동속도 강화";
    public static string Damaga = "공격력 강화";
    public static string Delay = "공격속도 강화";
    public static string Count = "무기 강화";
}
public enum WeaponType
{
    Spin,
    Shoot
}

public enum UpgradeType
{
    Hp,
    Speed,
    Count,
    Damage,
    Delay
}

public class UpgradeData
{
    public UpgradeType upgradeType;
    public int weight;

    public UpgradeData(UpgradeType _type, int _weight)
    {
        upgradeType = _type;
        weight = _weight;
    }
}