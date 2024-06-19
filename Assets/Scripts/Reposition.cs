using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D collider;

    private const float randomValue = 3.0f;
    private const int mapSize = 20;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckCollider(collision);
    }
    private void CheckCollider(Collider2D collision)
    {
        if (!collision.CompareTag(StringData.TagReposRange))
            return;

        Vector2 charPos = GameManager.instance.character.transform.position;
        Vector2 objPos = transform.position;

        float diffX = Mathf.Abs(charPos.x - objPos.x);
        float diffY = Mathf.Abs(charPos.y - objPos.y);

        Vector2 charDir = GameManager.instance.character.inputVector;

        if(transform.tag == StringData.TagBackground)
        {
            if (diffX > diffY)
            {
                transform.Translate(Vector3.right * charDir.x * mapSize * 2);
            }
            else if (diffX < diffY)
            {
                transform.Translate(Vector3.up * charDir.y * mapSize * 2);
            }
        }
        else if(transform.tag == StringData.TagMonster)
        {
            if (collider.enabled)
            {
                transform.Translate(new Vector2(Random.Range(-1 * randomValue, randomValue), Random.Range(-1 * randomValue, randomValue)) + charDir * mapSize);
            }
        }
    }
}
