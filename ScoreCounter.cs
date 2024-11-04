using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour // pretty much from apple picker book
{
    [Header("Dynamic")]
    public int score = 0;

    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    private void Update()
    {
        uiText.text = score.ToString("#,0");
    }
}