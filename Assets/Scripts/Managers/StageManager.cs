using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] backgrounds;

    private void Start()
    {
        SetStage();
    }
    public void SetStage()
    {
        int stage = Random.Range(0, backgrounds.Length);
        
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == stage);
        }
    }
}
