using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D collision;

    private const float randomValue = 3.0f;
    private const int mapSize = 30;

    private void Awake()
    {
        collision = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D _collision)
    {
        CheckCollider(_collision);
    }
    private void CheckCollider(Collider2D _collision)
    {
        if (!_collision.CompareTag(StringData.TagReposRange))
            return;

        Vector2 charPos = GameManager.instance.character.transform.position;
        Vector2 objPos = transform.position;

        float diffX = charPos.x - objPos.x;
        float diffY = charPos.y - objPos.y;

        float dirX = diffX < 0 ? -1 : 1;
        float dirY = diffY < 0 ? -1 : 1;

        diffX = Mathf.Abs(diffX);
        diffY = Mathf.Abs(diffY);

        if (transform.tag == StringData.TagBackground)
        {
            if (diffX > diffY)
            {
                transform.Translate(Vector3.right * dirX * mapSize * 2);
            }
            else if (diffX < diffY)
            {
                transform.Translate(Vector3.up * dirY * mapSize * 2);
            }
        }
        else if(transform.tag == StringData.TagMonster)
        {
            if (collision.enabled)
            {
                Vector2 distance = charPos - objPos;
                transform.Translate((distance * 2) + new Vector2(Random.Range(-1 * randomValue, randomValue), Random.Range(-1 * randomValue, randomValue)));
            }
        }
    }
}
