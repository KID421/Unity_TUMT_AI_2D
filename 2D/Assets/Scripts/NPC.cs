using UnityEngine;

public class NPC : MonoBehaviour
{
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
}
