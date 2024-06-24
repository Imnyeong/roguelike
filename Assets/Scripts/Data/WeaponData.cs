using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public WeaponType weaponType;
    public int weaponId;
    public string weaponName;
    public string weaponDesc;
    public Sprite weaponIcon;

    public float damage;
    public int count;
    public float speed;
}