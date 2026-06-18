using UnityEngine;

public class damageeffectcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroyEffect", 0.5f); // 0.5秒後にDestroyEffectメソッドを呼び出す
    }

    void DestroyEffect()
    {
        Destroy(gameObject); // このゲームオブジェクトを破壊する
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
