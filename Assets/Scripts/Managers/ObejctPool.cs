using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejctPool : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int key = 0; key < pools.Length; key++)
        {
            pools[key] = new List<GameObject>();
        }
    }

    public GameObject Get(int _key)
    {
        GameObject result = null;

        foreach(GameObject go in pools[_key])
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
            result = Instantiate(prefabs[_key], transform);
            pools[_key].Add(result);
        }

        return result;
    }
}
