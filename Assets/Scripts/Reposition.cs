using System.Collections;
using System.Collections.Generic;
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
        if (!collision.CompareTag("CharacterArea"))
            return;

        Vector2 charPos = GameManager.instance.character.transform.position;
        Vector2 objPos = transform.position;

        float diffX = Mathf.Abs(charPos.x - objPos.x);
        float diffY = Mathf.Abs(charPos.y - objPos.y);

        Vector2 charDir = GameManager.instance.character.inputVector;

        switch (transform.tag)
        {
            case "Background":
                {
                    if (diffX > diffY)
                    {
                        transform.Translate(Vector3.right * charDir.x * mapSize * 2);
                    }
                    else if (diffX < diffY)
                    {
                        transform.Translate(Vector3.up * charDir.y * mapSize * 2);
                    }
                    break;
                }
            case "Monster":
                {
                    if (collider.enabled)
                    {
                        transform.Translate(new Vector2(Random.Range(-1 * randomValue , randomValue), Random.Range(-1 * randomValue, randomValue)) + charDir * mapSize); 
                    }
                    break;
                }
        }
    }
}
