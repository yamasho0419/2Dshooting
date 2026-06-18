using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static ScoreManager instance;
    public SceneChanger sceneChanger; // SceneChangerへの参照
    private int score = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public TextMeshProUGUI scoreTextPro;
    void Start()
    {
        UpdateScorerText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScorerText();
    }

    void UpdateScorerText()
    {
        scoreTextPro.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
