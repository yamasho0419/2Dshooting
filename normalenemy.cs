using UnityEngine;

public class normalenemy : enemyStandard
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // 経過時間に基づいて、このフレームでの移動量を計算
        elapsedTime += Time.deltaTime;
        float x_velocity = Mathf.Cos(elapsedTime * frequency) * amplitude * frequency;
        float y_velocity = -downwardSpeed;

        // 計算した速度で移動させる
        Vector3 velocity = new Vector3(x_velocity, y_velocity, 0);
        transform.Translate(velocity * Time.deltaTime);
    }
}