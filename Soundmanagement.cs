using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Soundmanagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private AudioSource audioSource;
    public AudioClip destroySound; // 破壊音
    public AudioClip damagezero; // 発射音
    public AudioClip damageforme; // ダメージ音
    public AudioClip clearSound; // クリア音
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void damagesoundtoenemy()
    {
        audioSource.PlayOneShot(destroySound);
        Debug.Log("shootSound");
    }

    public void damegesoundtoplayer()
    {
        audioSource.PlayOneShot(damageforme);
        Debug.Log("damegeSound");
    }
    public void playersoundtozero()
    {
        audioSource.PlayOneShot(damagezero);
        Debug.Log("playerSound");
    }

    public void Clearsound()
    {
        audioSource.PlayOneShot(clearSound);
        Debug.Log("clearSound");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
