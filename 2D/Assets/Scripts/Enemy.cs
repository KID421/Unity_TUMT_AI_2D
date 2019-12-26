using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damage = 20;
    [Header("檢查地板")]
    public Transform checkPoint;

    private Rigidbody2D r2d;
    #endregion

    #region 事件
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 繪製圖示事件
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;                                // 圖示.顏色 = 顏色.黃色
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 1.5f);    // 圖示.繪製射線(中心點，方向 * 長度)
    }
    #endregion

    // 持續觸發
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
        {
            Track(collision.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "狐狸")
        {
            collision.gameObject.GetComponent<Fox>().Damage(damage);
        }
    }

    #region 方法
    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move()
    {
        //r2d.AddForce(new Vector2(-speed, 0)); // 世界座標
        r2d.AddForce(-transform.right * speed); // 區域座標 2D transform.right 右方、tranform.up 上方

        // 碰撞資訊 = 物理.射線碰撞
        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, -checkPoint.up, 1.5f, 1 << 8);

        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    /// <summary>
    /// 追蹤玩家
    /// </summary>
    /// <param name="target">玩家座標</param>
    private void Track(Vector3 target)
    {
        // 如果 玩家在左邊 角度 = 0
        // 如果 玩家在右邊 角度 = 180
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;   // new Vector3(0, 0, 0)
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    #endregion
}
