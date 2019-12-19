using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damage = 20;

    public Transform checkPoint;

    private Rigidbody2D r2d;

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

    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move()
    {
        r2d.AddForce(new Vector2(-speed, 0));
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {

    }
}
