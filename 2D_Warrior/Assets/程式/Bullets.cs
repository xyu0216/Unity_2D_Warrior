using UnityEngine;

public class Bullets : MonoBehaviour
{
    /// <summary>
    /// 子彈攻擊力
    /// </summary>
    public float attack;

    /// <summary>
    /// 碰撞事件:兩個物件都沒有勾選 IsTrigger使用
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果碰撞物件有Enemy腳本
        if (collision.gameObject.GetComponent<Enemy>())
        {
            //對Enemy呼叫Damage(攻擊力)
            collision.gameObject.GetComponent<Enemy>().Damage(attack);

        }

        if (collision.gameObject.GetComponent<Mushroom>())
        {
            //對Mushroom呼叫Damage(攻擊力)
            collision.gameObject.GetComponent<Mushroom>().Damage(attack);

        }
        if (collision.gameObject.GetComponent<FlyingEyes>())
        {
            //對Mushroom呼叫Damage(攻擊力)
            collision.gameObject.GetComponent<FlyingEyes>().Damage(attack);

        }
        if (collision.gameObject.GetComponent<Goblin>())
        {
            //對Mushroom呼叫Damage(攻擊力)
            collision.gameObject.GetComponent<Goblin>().Damage(attack);

        }
        Destroy(gameObject);
    }
}
