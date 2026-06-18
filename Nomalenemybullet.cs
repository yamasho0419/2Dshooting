using System.Threading.Tasks;
using UnityEngine;

public class Nomalenemybullet : enemybulletstandard
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        // この弾はプレイヤーを狙わず、常に真下に飛ぶ
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 画面外に出たら破棄する（親のUpdate()にある移動処理は不要なので、必要な部分だけ持ってくる）
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
}