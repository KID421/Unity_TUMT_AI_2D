using UnityEngine;                  // 引用 Unity API - API 倉庫 功能、工具
using UnityEngine.Events;           // 引用 事件 API
using UnityEngine.UI;               // 引用 介面 API

public class Fox : MonoBehaviour    // 類別 類別名稱
{
    #region 欄位
    // 成員：欄位、屬性、方法、事件
    // 修飾詞 類型 名稱 指定 值；
    [Header("移動速度"), Range(0, 1000)]
    public int speed = 50;                  // 整數
    [Header("跳躍高度"), Range(0, 2000)]
    public float jump = 2.5f;               // 浮點數
    [Header("是否在地板上")]
    public bool isGround;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    [Header("血量吧條")]
    public Image hpBar;
    [Header("結束畫面")]
    public GameObject final;
    [Header("音效區域")]
    public AudioClip soundProp;
    [Header("吃東西事件")]
    public UnityEvent onEat;

    //public string foxName = "狐狸";         // 字串
    //public bool pass = false;               // 布林值 - true/false

    //private Transform tra;
    private Rigidbody2D r2d;
    private AudioSource aud;
    private Animator ani;
    private float hpMax;
    #endregion

    #region 事件
    // 事件：在特定時間點會以指定頻率執行的方法
    // 開始事件：遊戲開始時執行一次
    private void Start()
    {
        // 泛型 <T>
        //tra = GetComponent<Transform>();
        r2d = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();

        hpMax = hp;
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
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
            ani.SetBool("跳躍開關", false);
        }
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
        ani.SetBool("跑步開關", Input.GetAxisRaw("Horizontal") != 0);
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
            ani.SetBool("跳躍開關", true);
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
        hpBar.fillAmount = hp / hpMax;

        if (hp <= 0) final.SetActive(true);
    }
    #endregion
}
