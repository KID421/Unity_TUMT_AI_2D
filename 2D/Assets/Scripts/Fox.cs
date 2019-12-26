using UnityEngine;                  // 引用 Unity API - API 倉庫 功能、工具
using UnityEngine.Events;           // 引用 事件 API

public class Fox : MonoBehaviour    // 類別 類別名稱
{
    #region 欄位
    // 成員：欄位、屬性、方法、事件
    // 修飾詞 類型 名稱 指定 值；
    public int speed = 50;                  // 整數
    public float jump = 2.5f;               // 浮點數
    public string foxName = "狐狸";         // 字串
    public bool pass = false;               // 布林值 - true/false
    public bool isGround;

    public UnityEvent onEat;
    public AudioClip soundProp;

    //private Transform tra;
    private Rigidbody2D r2d;
    private AudioSource aud;
    #endregion
    [Header("血量"), Range(0, 200)]
    public float hp = 100;

    #region 事件
    // 事件：在特定時間點會以指定頻率執行的方法
    // 開始事件：遊戲開始時執行一次
    private void Start()
    {
        // 泛型 <T>
        //tra = GetComponent<Transform>();
        r2d = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
    }

    // 更新事件：每秒執行約 60 次
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn();
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
        Jump();
    }

    // 固定更新事件：每禎 0.002 秒
    private void FixedUpdate()
    {
        Walk(); // 呼叫方法
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        //Debug.Log("碰到東西：" + collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "櫻桃")
        {
            aud.PlayOneShot(soundProp, 1.2f);
            Destroy(collision.gameObject);  // 刪除
            onEat.Invoke();                 // 呼叫事件
        }
    }
    #endregion

    #region 方法
    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        if (r2d.velocity.magnitude < 10)
            r2d.AddForce(new Vector2(speed * Input.GetAxisRaw("Horizontal"), 0));
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }

    // 參數語法：類型 名稱
    /// <summary>
    /// 轉彎
    /// </summary>
    /// <param name="direction">方向，左轉為 180，右轉為 0</param>
    private void Turn(int direction = 0)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }

    public void Damage(float damage)
    {
        hp -= damage;
    }
    #endregion
}
