using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    private int id = 0;
    private int weaponId = 1;
    private float damage = 10;
    private int count = 3;
    private float speed;

    private const int circle = 360;
    private const float upValue = 1.5f;

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        ActionWeapon();
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

            weapon.GetComponent<Weapon>().Init(damage, -1);
        }
    }

    private void ActionWeapon()
    {
        switch (id)
        {
            case 0:
                {
                    transform.Rotate(Vector3.back * speed * Time.deltaTime);
                    break;
                }
        }
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
