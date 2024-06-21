using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejctPool : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefabs;
    private List<GameObject>[] monsterPools;

    [SerializeField] private GameObject[] weaponPrefabs;
    private List<GameObject>[] weaponPools;

    private void Awake()
    {
        monsterPools = new List<GameObject>[monsterPrefabs.Length];
        weaponPools = new List<GameObject>[weaponPrefabs.Length];

        for(int key = 0; key < monsterPools.Length; key++)
        {
            monsterPools[key] = new List<GameObject>();
        }
        for (int key = 0; key < weaponPools.Length; key++)
        {
            weaponPools[key] = new List<GameObject>();
        }
    }
    public GameObject GetMonster(int _key)
    {
        GameObject result = null;

        foreach(GameObject go in monsterPools[_key])
        {
            if(!go.activeSelf)
            {
                result = go;
                result.SetActive(true);
                break;
            }
        }
        if(result == null)
        {
            result = Instantiate(monsterPrefabs[_key], transform);
            monsterPools[_key].Add(result);
        }
        return result;
    }
    public GameObject GetWeapon(int _key)
    {
        GameObject result = null;

        foreach (GameObject go in weaponPools[_key])
        {
            if (!go.activeSelf)
            {
                result = go;
                result.SetActive(true);
                break;
            }
        }
        if (result == null)
        {
            result = Instantiate(weaponPrefabs[_key], transform);
            weaponPools[_key].Add(result);
        }
        return result;
    }
}
