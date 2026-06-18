using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SceneChanger instance;
    public Soundmanagement soundmanagement;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            soundmanagement = FindAnyObjectByType<Soundmanagement>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    public void ChangeSceneClear()
    {
        SceneManager.LoadScene("ClearScene");
        soundmanagement.Clearsound();
    }

    public void gameover()
    {
        Invoke("ChangeScenegameover", 2f);
        soundmanagement.Clearsound();
    }


    public void ChangeScenegameover()
    {
        SceneManager.LoadScene("GameOverScene");
        
    }

    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "StartScene" || currentScene.name == "ClearScene" || currentScene.name == "GameoverScene")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainGameScene");
            }
        }
    }
}
