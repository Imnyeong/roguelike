using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    private WeaponType weaponType;
    private int weaponId;
    private float damage;
    private int count;
    private float speed;

    private float timer = 0.0f;

    private const int circle = 360;
    private const float upValue = 1.5f;
    private const float spinPosition= 0.5f;

    private Character character;

    #region Unity Life Cycle
    private void Awake()
    {
        Init();
    }
    private void FixedUpdate()
    {
        ActionWeapon();
    }
    #endregion
    private void Init()
    {
        character = GetComponentInParent<Character>();
    }
    public void SetData(WeaponData _data)
    {
        gameObject.name = _data.name;
        weaponType = _data.weaponType;
        weaponId = _data.weaponId;
        damage = _data.damage;
        count = _data.count;
        speed = _data.speed;

        switch (weaponType)
        {
            case WeaponType.Spin:
                {
                    transform.Translate(this.transform.up * spinPosition, Space.World);
                    SetWeapon();
                    break;
                }
            case WeaponType.Shoot:
                {
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
                weapon = GameManager.instance.objectPool.GetWeapon(weaponId).transform;
                weapon.parent = this.transform;
            }
            weapon.localPosition = Vector3.zero;
            weapon.localRotation = Quaternion.identity;

            Vector3 rotate = Vector3.forward * circle * index / count;
            weapon.Rotate(rotate);
            weapon.Translate(weapon.up * upValue, Space.World);
            weapon.GetComponent<Weapon>().SetWeapon(damage, weaponType, Vector2.zero);
        }
    }

    private void ActionWeapon()
    {
        switch (weaponType)
        {
            case WeaponType.Spin:
                {
                    transform.Rotate(Vector3.back * speed * Time.fixedDeltaTime);
                    break;
                }
            case WeaponType.Shoot:
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

        Transform bullet = GameManager.instance.objectPool.GetWeapon(weaponId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        bullet.GetComponent<Weapon>().SetWeapon(damage, weaponType, direction, count, speed);
    }
    public void UpgradeWeapon(float _damage, float _speed, int _count)
    {
        damage += _damage;
        if(weaponType == WeaponType.Shoot)
        {
            _speed = 1 / _speed;
        }
        speed += _speed;
        count += _count;

        if(weaponType == WeaponType.Spin)
        {
            SetWeapon();
        }
    }
}
