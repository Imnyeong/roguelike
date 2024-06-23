using UnityEngine;

public class LocalDataBase : MonoBehaviour
{
    public static LocalDataBase instance;
    public CharacterData[] characterDatas;
    public WeaponData[] weaponDatas;
    public MonsterData[] monsterDatas;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        SetData();
    }
    private void SetData()
    {
        characterDatas = Resources.LoadAll<CharacterData>(StringData.pathCharacterData);
        weaponDatas = Resources.LoadAll<WeaponData>(StringData.pathWeaponData);
        monsterDatas = Resources.LoadAll<MonsterData>(StringData.pathMonsterData);
    }
}
