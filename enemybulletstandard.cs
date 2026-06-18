using System.Threading.Tasks;
using UnityEngine;

public class enemybulletstandard : MonoBehaviour
{
    private SceneChanger sceneChanger; // SceneChangerへの参照
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerController playerController;
    private Soundmanagement soundmanagement;
    private enemyStandard enemyStandard;
    protected GameObject player;
    [SerializeField]
    protected float speed = 5f;
    protected BulletType bulletType; // 弾の種類を保持する変数
    protected Vector2 direction;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerController.damegePlayer();
            if(playerController.playerHealth > 0)
            {
                soundmanagement.damegesoundtoplayer();
            }else if(playerController.playerHealth <= 0)
            {
                soundmanagement.playersoundtozero();
            }
            
            //enemyStandard.damagegenerate();
            //enemyStandard.StartCoroutine(enemyStandard.Damage());
        }
    }

    public virtual void Initialize(BulletType type)
    {
        this.bulletType = type; // 自身の種類をセット

        // 弾の種類に応じて速度を変更する
        if (this.bulletType == BulletType.Fast)
        {
            speed = 12f;
        }
        else // BulletType.Normal やその他の場合
        {
            speed = 5f;
        }
    }

    protected virtual void Start()
    {
        sceneChanger = FindAnyObjectByType<SceneChanger>();
        enemyStandard = FindAnyObjectByType<enemyStandard>();
        playerController = FindAnyObjectByType<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
        soundmanagement = FindAnyObjectByType<Soundmanagement>();

        // playerがシーンに存在するかチェックする
        if (player != null)
        {
            // プレイヤーが存在する場合のみ、プレイヤーの方向を向く
            direction = (player.transform.position - transform.position).normalized;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // 設定された方向と速度で弾を移動させる
        //transform.Translate(direction * speed * Time.deltaTime);

        // directionの向きをSceneビューに赤い線で描画する (長さ5)
        Debug.DrawRay(transform.position, direction * 30f, Color.red);

        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
}
