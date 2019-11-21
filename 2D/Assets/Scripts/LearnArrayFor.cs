using UnityEngine;

public class LearnArrayFor : MonoBehaviour
{
    public string say = "嗨，你好嗎?";

    // 類型 陣列[] = new 類型[數量]
    public float[] values = new float[7];
    // { 陣列資料 }
    public int[] scores = { 100, 80, 90, 30, 40 };

    public Color[] colors = new Color[5];

    private void Start()
    {
        // 陣列編號從 0 開始
        print("第三個字：" + say[2]);
        // 取得陣列長度：陣列.Length
        print("陣列的長度：" + say.Length);

        // 存放陣列
        scores[2] = 60;
        // 取得陣列
        print(scores[2]);

        for (int i = 1; i <= 10; i++)
        {
            print("數字：" + i);
        }

        for (int i = 0; i < scores.Length; i++)
        {
            print("分數陣列：" + scores[i]);
        }
    }
}
