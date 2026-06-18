using UnityEngine;

public class BulletContoroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Enemycounter enemycounter;
    public Soundmanagement soundmanagement;
    public AudioClip hitSound; // 敵に当たった時の音
    private float speed = 10f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 衝突した相手からenemyStandardコンポーネントを取得
            enemyStandard enemy = other.GetComponent<enemyStandard>();
            // コンポーネントが取得できたらdamagegenerateを呼び出す
            if (enemy != null)
            {
                enemy.damagegenerate();
            }

            // hitSoundが設定されていれば、敵の位置で音を再生
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, other.transform.position);
            }
            ScoreManager.instance.AddScore(10);
            Destroy(other.gameObject);
            Destroy(gameObject);
            enemycounter.dowuncounter();
            soundmanagement.damagesoundtoenemy();
        }
        if(other.CompareTag("enemybullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        enemycounter = FindAnyObjectByType<Enemycounter>();
        soundmanagement = FindAnyObjectByType<Soundmanagement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > 20f)
        {
            Destroy(gameObject);
        }
    }
}
