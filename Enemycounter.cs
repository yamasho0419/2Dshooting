using UnityEngine;
using TMPro;

public class Enemycounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int enemyCount;
    public TextMeshProUGUI enemyCountText;
    public SceneChanger sceneChanger;
    public EnemySpawner enemySpawner;
    private int nomalspwnerlmit;
    private int toplayerenemyspwnerlmit;
    public void dowuncounter()
    {
        enemyCount--;
        UpdateEnemyCountText();
        if (enemyCount <= 0)
        {
            //Debug.Log("All enemies defeated!");
            //sceneChanger.ChangeSceneClear();
        }
    }

    public int getenemycount()
    {
        return enemyCount;
    }


    public void maxenemycount()
    {
        nomalspwnerlmit = enemySpawner.getNomalspwnerlmit();
        toplayerenemyspwnerlmit = enemySpawner.getToplayerenemyspwnerlmit();
        enemyCount = nomalspwnerlmit + toplayerenemyspwnerlmit;
        Debug.Log("Max Enemy Count: " + enemyCount);
        enemySpawner.normalspwancount = 0;
        enemySpawner.toplayerspwancount = 0;
    }
    void Start()
    {
        maxenemycount();
        UpdateEnemyCountText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void UpdateEnemyCountText()
    {
        enemyCountText.text = "Enemy Counnt; " + enemyCount.ToString();
    }
}
