using UnityEngine;

public class LearnArrayFor : MonoBehaviour
{
    public string say = "嗨，你好嗎?";

    private void Start()
    {
        // 陣列編號從 0 開始
        print("第三個字：" + say[2]);
        // 取得陣列長度：陣列.Length
        print("陣列的長度：" + say.Length);
    }
}
