using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int weaponId;
    [SerializeField] private float damage;
    [SerializeField] private int count;
    private float speed;
    private float timer = 0.0f;
    private const int circle = 360;
    private const float upValue = 1.5f;
    private Character character;

    #region Unity Life Cycle
    private void Awake()
    {
        SetCharacter();
    }
    private void Start()
    {
        Init();
    }
    private void FixedUpdate()
    {
        ActionWeapon();
    }
    #endregion
    private void SetCharacter()
    {
        character = GetComponentInParent<Character>();
    }
    private void Init()
    {
        switch(id)
        {
            case 0:
                {
                    speed = 150;
                    SetWeapon();
                    break;
                }
            default :
                {
                    speed = 1.0f;
                    break;
                }
        }
    }
    private void SetWeapon()
    {
        for(int index = 0; index < count; index++)
        {
            Transform weapon;

            if (index < transform.childCount)
            {
                weapon = transform.GetChild(index);
            }
            else
            {
                weapon = GameManager.instance.objectPool.Get(weaponId).transform;
                weapon.parent = this.transform;
            }
            weapon.localPosition = Vector3.zero;
            weapon.localRotation = Quaternion.identity;

            Vector3 rotate = Vector3.forward * circle * index / count;
            weapon.Rotate(rotate);
            weapon.Translate(weapon.up * upValue, Space.World);
            weapon.GetComponent<Weapon>().Init(damage, -1, Vector2.zero);
        }
    }

    private void ActionWeapon()
    {
        switch (id)
        {
            case 0:
                {
                    transform.Rotate(Vector3.back * speed * Time.fixedDeltaTime);
                    break;
                }
            default:
                {
                    timer += Time.deltaTime;
                    if (timer > speed)
                    {
                        Fire();
                        timer = 0.0f;
                    }
                    break;
                }
        }
    }
    private void Fire()
    {
        if (character.tracker.currentTarget == null)
            return;

        Vector3 targetPos = character.tracker.currentTarget.position;
        Vector3 direction = (targetPos - transform.position).normalized;

        Transform bullet = GameManager.instance.objectPool.Get(weaponId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        bullet.GetComponent<Weapon>().Init(damage, count, direction);
    }
    public void UpgradeWeapon(float _damage, int _count)
    {
        damage = _damage;
        count += _count;

        if(id == 0)
        {
            SetWeapon();
        }
    }
}
