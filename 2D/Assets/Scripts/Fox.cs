using UnityEngine;                  // 引用 Unity API - API 倉庫 功能、工具

public class Fox : MonoBehaviour    // 類別 類別名稱
{
    // 成員：欄位、屬性、方法、事件
    // 修飾詞 類型 名稱 指定 值；
    public int speed = 50;                  // 整數
    public float jump = 2.5f;               // 浮點數
    public string foxName = "狐狸";         // 字串
    public bool pass = false;               // 布林值 - true/false

    // 事件：在特定時間點會以指定頻率執行的方法
    // 開始事件：遊戲開始時執行一次
    private void Start()
    {
        // API 把訊息輸出到 Unity
        Debug.Log("哈囉，沃德~@3@");
        Debug.Log("!!!!!!!!");
        // Log(object message) API 說明書
        // object 指任何類型，例如：777，1.5f，"嗨~"，true/false
        // message 指說明這裡要放什麼，這裡指的是訊息
        Debug.Log(777);
        Debug.Log(true);
        Debug.Log(1.5f);
        // 警告訊息
        Debug.LogWarning("警告訊息");
        // 錯誤訊息
        Debug.LogError("錯誤訊息");
    }
}
