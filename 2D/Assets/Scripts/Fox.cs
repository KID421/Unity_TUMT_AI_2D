using UnityEngine;                  // 引用 Unity API - API 倉庫 功能、工具

public class Fox : MonoBehaviour    // 類別 類別名稱
{
    // 成員：欄位、屬性、方法、事件
    // 修飾詞 類型 名稱 指定 值；
    public int speed = 50;                  // 整數
    public float jump = 2.5f;               // 浮點數
    public string foxName = "狐狸";         // 字串
    public bool pass = false;               // 布林值 - true/false

    private Rigidbody2D r2d;
    //private Transform tra;

    // 事件：在特定時間點會以指定頻率執行的方法
    // 開始事件：遊戲開始時執行一次
    private void Start()
    {
        // 泛型 <T>
        r2d = GetComponent<Rigidbody2D>();
        //tra = GetComponent<Transform>();
    }

    // 更新事件：每秒執行約 60 次
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) TurnRight();
        if (Input.GetKeyDown(KeyCode.A)) TurnLeft();
    }

    // 固定更新事件：每禎 0.002 秒
    private void FixedUpdate()
    {
        Walk(); // 呼叫方法
    }

    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
    /// <summary>
    /// 右轉
    /// </summary>
    private void TurnRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    /// <summary>
    /// 左轉
    /// </summary>
    private void TurnLeft()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

}
