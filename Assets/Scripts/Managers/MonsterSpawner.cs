using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private Transform[] spawnPoints;
    private MonsterData[] monsterData;
    private float timer;
    private const float spawnDelay = 1.0f;
    #region Unity Life Cycle
    private void Awake()
    {
        Init();
        SetSpawnPoints();
    }
    private void Update()
    {
        CheckSpawn();
    }
    #endregion
    private void Init()
    {
        monsterData = Resources.LoadAll<MonsterData>(StringData.pathMonsterData);
    }
    private void SetSpawnPoints()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }
    private void CheckSpawn()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            Spawn();
            timer = 0;
        }
    }
    private void Spawn()
    {
        GameObject monster = GameManager.instance.objectPool.GetMonster(0);
        monster.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
        monster.GetComponent<Monster>().SetData(monsterData[0]);
    }
}
