using UnityEngine;
using UnityEngine.UI;
using TMPro;    


public class stagecontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int enemyCount;
    public Enemycounter enemycounter;
    public SceneChanger sceneChanger;
    private EnemySpawner enemySpawner;
    public TextMeshProUGUI stageText;
    private int currentStage = 1;
    public AudioClip clearSound;
    private AudioSource audioSource;
    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーがいない（倒された）場合は、ステージ進行処理を行わない
        if (enemycounter.getenemycount() > 0 && FindObjectOfType<PlayerController>() == null) return;

        enemyCount = enemycounter.getenemycount();
        if (enemyCount <= 0 && currentStage == 1)
        {
            enemySpawner.spawnstage2();
            stageText.text = "Stage 2";
            currentStage = 2;
            audioSource.PlayOneShot(clearSound);
        }
        else if (enemyCount <= 0 && currentStage == 2)
        {
            enemySpawner.spawnstage3();
            stageText.text = "Stage 3";
            audioSource.PlayOneShot(clearSound);
            currentStage = 3;
        }else if(enemyCount <= 0 && currentStage == 3)
        {
            enemySpawner.spawnstage4();
            stageText.text = "Stage 4";
            currentStage = 4;
            audioSource.PlayOneShot(clearSound);
        }
        else if (enemyCount <= 0 && currentStage == 4)
        {
            sceneChanger.ChangeSceneClear();
        }
    }
}
