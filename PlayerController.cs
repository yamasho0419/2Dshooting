using System.Collections;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 12f;
    private float minX, maxX;
    public GameObject bulletPrefab;
    public Sprite defaultpicture;
    public Sprite damegeeffectpicture;
    public float damegeeffecttime = 1f;
    private SpriteRenderer spriteRenderer;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public Transform firePoint;
    private float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public AudioClip shotSound;
    private AudioSource audioSource;
    public int playerHealth = 3;
    private bool isInvincible = false;
    public SceneChanger sceneChanger;
    public TextMeshProUGUI PlayerhealthText;
    public GameObject damegeenemyeffectpictureprefab;
    public void damegePlayer()
    {
        // 体力が0以下の場合は、以降の処理をすべて中断する
        if (playerHealth <= 0 || isInvincible) return;

        playerHealth--;
        if(playerHealth == 2)
        {
            Debug.Log("2");
            Destroy(health3);
        }else if(playerHealth == 1)
        {
            Destroy(health2);
        }else if(playerHealth == 0)
        {
            Destroy(health1);
        }
        UpdateplayerhealthText();
        Debug.Log("Player Health: " + playerHealth);
        if (playerHealth <= 0)
        {
            Debug.Log("Player Defeated!");
            Instantiate(damegeenemyeffectpictureprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            sceneChanger.gameover();
        }
        else
        {
            // 体力が残っている場合のみ、ダメージエフェクトと無敵化処理を行う
            StartCoroutine(Damage());
            StartCoroutine(BecomeInvincible());
        }
    }
    IEnumerator BecomeInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.2f); // 2秒間無敵状態
        isInvincible = false;
    }

    void defeatedplayer()
    {
        sceneChanger.ChangeScenegameover();
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        audioSource.PlayOneShot(shotSound);
    }
    void Start()
    {
        minX = -19f;
        maxX = 6f;
        audioSource = GetComponent<AudioSource>();
        UpdateplayerhealthText();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultpicture = spriteRenderer.sprite;
        sceneChanger = FindAnyObjectByType<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(moveInput * speed * Time.deltaTime, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void UpdateplayerhealthText()
    {
        PlayerhealthText.text = "Player Health:";
    }

    public IEnumerator Damage()
    {
        spriteRenderer.sprite = damegeeffectpicture;
        yield return new WaitForSeconds(damegeeffecttime);
        spriteRenderer.sprite = defaultpicture;
    }
}
