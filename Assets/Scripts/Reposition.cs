using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("CharacterArea"))
            return;

        Vector2 charPos = GameManager.instance.character.transform.position;
        Vector2 objPos = transform.position;

        float diffX = Mathf.Abs(charPos.x - objPos.x);
        float diffY = Mathf.Abs(charPos.y - objPos.y);

        Vector2 charDir = GameManager.instance.character.inputVector;

        float dirX = charDir.x < 0 ? -1 : 1;
        float dirY = charDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Background":
                {
                    if(diffX > diffY)
                    {
                        transform.Translate(Vector3.right * dirX * 40);
                    }
                    else if(diffX < diffY)
                    {
                        transform.Translate(Vector3.up * dirY * 40);
                    }
                    break;
                }
        }
    }
}
