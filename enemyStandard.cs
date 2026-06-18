using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))] // AudioSourceコンポーネントを必須にする
public class enemyStandard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SceneChanger sceneChanger;
    public GameObject normalBulletPrefab;
    public GameObject fastBulletPrefab;
    public Transform enemyfirePoint;
    public AudioClip shootSound; // インスペクターで設定する発射音
    private AudioSource audioSource; // 音声再生用のコンポーネント
    [Header("Damage Effect")]
    public float damegeeffecttime = 1f;
    public Sprite damegeenemyeffectpicture;
    public GameObject damegeenemyeffectpictureprefab;

    private SpriteRenderer spriteRenderer;
    private Sprite defaultSprite;
    private float fireDelay = 1f;
    private float fireRate = 2f;
    public float elapsedTime = 0f;

    protected Vector3 startPosition; // 初期位置を記憶する変数
    public float amplitude = 10f;   // 左右の振れ幅
    public float frequency = 1f;   // 揺れる速さ
    public float downwardSpeed = 1f; // 下に移動する速さ
    public BulletType bulletType = BulletType.Normal; // 弾の種類をenumで管理

    protected virtual void Shoot()
    {
        // 弾の種類に応じて使用するプレハブを選択
        GameObject bulletToInstantiate = null;
        switch (bulletType)
        {
            case BulletType.Normal:
                bulletToInstantiate = normalBulletPrefab;
                break;
            case BulletType.Fast:
                bulletToInstantiate = fastBulletPrefab;
                break;
        }

        if (bulletToInstantiate != null && enemyfirePoint != null)
        {
            GameObject bulletGO = Instantiate(bulletToInstantiate, enemyfirePoint.position, enemyfirePoint.rotation);
            enemybulletstandard bullet = bulletGO.GetComponent<enemybulletstandard>();
            if (bullet != null)
            {
                // 弾の初期設定を行う
                bullet.Initialize(bulletType);
            }
            else
            {
                Debug.LogWarning("bulletPrefabにenemybulletstandardコンポーネントがありません。");
            }
            if (audioSource != null && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }
    protected virtual void Start()
    {
        sceneChanger = FindAnyObjectByType<SceneChanger>(); // シーン内からSceneChangerを探して参照をセットする
        startPosition = transform.position; // ゲーム開始時の位置を保存
        audioSource = GetComponent<AudioSource>(); // AudioSourceコンポーネントを取得
        InvokeRepeating("Shoot", fireDelay, fireRate);
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    // Updateは子クラスで上書きされるため、共通の画面外チェックはLateUpdateで行う
    protected virtual void Update()
    {
        if (transform.position.y <= -6f)
        {
            // Y座標のみを10fにリセットし、XとZ座標は現在の値を維持する
            transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
        }
    }

    public void damagegenerate()
    {
        Debug.Log("Enemy Damaged!");
        Instantiate(damegeenemyeffectpictureprefab, transform.position, Quaternion.identity);
    }
   /* public IEnumerator Damage()
    {
        spriteRenderer.sprite = damegeeffectpicture;
        yield return new WaitForSeconds(damegeeffecttime);
        spriteRenderer.sprite = defaultSprite;
    }*/
}
