using UnityEngine;
using UnityEngine.UI;   // 引用 介面 API

public class NPC : MonoBehaviour
{
    // 定義列舉
    // 修飾詞 列舉 列舉名稱 { 列舉內容, .... }
    public enum state
    {
        // 一般、尚未完成、完成
        normal, notComplete, complete
    }
    // 使用列舉
    // 修飾詞 類型 名稱
    public state _state;

    [Header("對話")]
    public string sayStart = "嗨，你好，我可以請你幫我蒐集十顆櫻桃嗎？";
    public string sayNotComplete = "你還沒找到十顆櫻桃喔...";
    public string sayComplete = "感謝你幫我找到十顆櫻桃~";
    [Header("對話速度")]
    public float speed = 1.5f;
    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;

    // 2D 觸發事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果碰到物件為"狐狸"
        if (collision.name == "狐狸")
        {
            // 畫布.顯示
            objCanvas.SetActive(true);
            // 文字介面.文字 = 對話1
            textSay.text = sayStart;
        }
    }
}
