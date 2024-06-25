using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Transform warnnigArea;

    private float timer;

    private const int minX = -29;
    private const int maxX = 30;

    private const int minY = -20;
    private const int maxY = 21;

    private Vector2 spawnPos;
    private const float spawnDelay = 1.0f;
    private int currentMonster = 0;
    #region Unity Life Cycle
    private void Start()
    {
        SetMonster();
    }
    private void Update()
    {
        CheckSpawn();
    }
    #endregion
    public void SetMonster()
    {
        currentMonster = Random.Range(0, LocalDataBase.instance.monsterDatas.Length);
    }
    private void CheckSpawn()
    {
        if(timer == 0)
        {
            Warnning();
        }

        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            Spawn();
            timer = 0;
        }
    }
    private void Warnning()
    {
        int x = Random.Range(minX, maxX);
        int y = Random.Range(minY, maxY);

        spawnPos = new Vector2(x, y);
        warnnigArea.position = spawnPos;
        warnnigArea.gameObject.SetActive(true);
    }
    private void Spawn()
    {
        warnnigArea.gameObject.SetActive(false);
        GameObject monster = GameManager.instance.objectPool.GetMonster(0);
        monster.transform.position = spawnPos;
        monster.GetComponent<Monster>().SetData(LocalDataBase.instance.monsterDatas[currentMonster]);
    }
}
