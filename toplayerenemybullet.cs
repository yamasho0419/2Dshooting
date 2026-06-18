using UnityEngine;

public class toplayerenemybullet : enemybulletstandard
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        Debug.Log(direction);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
