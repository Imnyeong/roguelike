[System.Serializable]
public class MonsterData
{
    public float spawnDelay;
    public int spriteType;
    public int hp;
    public float speed;
}

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
    // Layer
}