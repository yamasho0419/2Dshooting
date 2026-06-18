using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int nomalspwnerlmit = 1;
    private int toplayerenemyspwnerlmit = 2;
    public int normalspwancount = 0;
    public int toplayerspwancount = 0;
    public GameObject normalenemyPrefab;
    public GameObject toplayerenemyPrefab;
    public Enemycounter enemycounter;
    private float spawnInterval = 1f;
    public GameObject nomale_1_1;
    public GameObject toplayer_1_1;
    public GameObject toplayer_1_2;
    public GameObject nomale_2_1;
    public GameObject toplayer_2_1;
    public GameObject toplayer_2_2;
    public GameObject nomale_3_1;
    public GameObject nomale_3_2;
    public GameObject nomale_3_3;
    public GameObject normale_4_1;
    public GameObject toplayer_4_1;
    public GameObject toplayer_4_2;

    void Start()
    {
        InvokeRepeating("SpawnEnemynomal1", 0.5f, spawnInterval);
        InvokeRepeating("SpawnEnemytoplayer1", 1f, spawnInterval * 2);
        enemycounter = FindObjectOfType<Enemycounter>();
    }

    public int getNomalspwnerlmit()
    {
        return nomalspwnerlmit;
    }

    public int getToplayerenemyspwnerlmit()
    {
        return toplayerenemyspwnerlmit;
    }

   void SpawnEnemy(int limitm, ref int count, GameObject enemyPrefab, GameObject spawnPoint, BulletType bulletType)
    {
        if (count >= limitm)
        {
            return; // 既に敵が上限に達している場合はスポーンしない
        }
        count++;
        GameObject enemyGO = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemyStandard enemy = enemyGO.GetComponent<enemyStandard>();
        if (enemy != null)
        {
            // 生成した敵が撃つ弾の種類をここで設定する
            enemy.bulletType = bulletType;
        }
    }

    void SpawnEnemynomal1()
    {
        SpawnEnemy(nomalspwnerlmit, ref normalspwancount, normalenemyPrefab, nomale_1_1, BulletType.Normal);
    }

    void SpawnEnemytoplayer1()
    {
        SpawnEnemy(toplayerenemyspwnerlmit, ref toplayerspwancount, toplayerenemyPrefab, toplayer_1_1, BulletType.Normal);
        SpawnEnemy(toplayerenemyspwnerlmit, ref toplayerspwancount, toplayerenemyPrefab, toplayer_1_2, BulletType.Normal);
    }

    void SpawnEnemynomal2()
    {
        SpawnEnemy(nomalspwnerlmit, ref normalspwancount, normalenemyPrefab, nomale_2_1, BulletType.Fast);
    }

    void SpawnEnemytoplayer2()
    {
        SpawnEnemy(toplayerenemyspwnerlmit, ref toplayerspwancount, toplayerenemyPrefab, toplayer_2_1, BulletType.Normal);
        SpawnEnemy(toplayerenemyspwnerlmit, ref toplayerspwancount, toplayerenemyPrefab, toplayer_2_2, BulletType.Normal);
    }

    void SpawnEnemynomal3()
    {
        SpawnEnemy(nomalspwnerlmit, ref normalspwancount, normalenemyPrefab, nomale_3_1, BulletType.Fast);
        SpawnEnemy(nomalspwnerlmit, ref normalspwancount, normalenemyPrefab, nomale_3_2, BulletType.Fast);
        SpawnEnemy(nomalspwnerlmit, ref normalspwancount, normalenemyPrefab, nomale_3_3, BulletType.Fast);
    }

    void SpawnEnemytoplayer3()
    {
        //SpawnEnemy(toplayerenemyspwnerlmit, ref toplayerspwancount, toplayerenemyPrefab, toplayer_3_1, BulletType.Normal);
    }

    void SpawnEnemynomal4()
    {
        SpawnEnemy(nomalspwnerlmit, ref normalspwancount, normalenemyPrefab, normale_4_1, BulletType.Fast);
    }
    
    void SpawnEnemytoplayer4()
    {
        SpawnEnemy(toplayerenemyspwnerlmit, ref toplayerspwancount, toplayerenemyPrefab, toplayer_4_1, BulletType.Fast);
        SpawnEnemy(toplayerenemyspwnerlmit, ref toplayerspwancount, toplayerenemyPrefab, toplayer_4_2, BulletType.Fast);
    }


    public void spawnstage2()
    {
        //ステージ3のスポーン処理
        nomalspwnerlmit = 2;
        toplayerenemyspwnerlmit = 4;
        CancelInvoke();

        InvokeRepeating("SpawnEnemynomal2", 0.5f, spawnInterval);
        InvokeRepeating("SpawnEnemytoplayer2", 1f, spawnInterval * 2);
        enemycounter.maxenemycount();
    }

    public void spawnstage3()
    {
        //ステージ3のスポーン処理
        nomalspwnerlmit = 12;
        toplayerenemyspwnerlmit = 0;
        CancelInvoke();

        InvokeRepeating("SpawnEnemynomal3", 0.5f, spawnInterval);
        //InvokeRepeating("SpawnEnemytoplayer3", 1f, spawnInterval * 2);
        enemycounter.maxenemycount();
    }

    public void spawnstage4()
    {
        //ステージ4のスポーン処理
        nomalspwnerlmit = 4;
        toplayerenemyspwnerlmit = 6;
        CancelInvoke();

        InvokeRepeating("SpawnEnemynomal4", 0.5f, spawnInterval);
        InvokeRepeating("SpawnEnemytoplayer4", 1f, spawnInterval * 2);
        enemycounter.maxenemycount();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
