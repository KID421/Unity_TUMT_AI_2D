using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    // 插值：取兩個值之間的位置
    // 0 與 10 中間 50%
    // 插值(0，10，0.5f) => 5

    public Vector2 a = new Vector2(0, 0);
    public Vector2 b = new Vector2(10, 10);

    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color myColor;

    private void Start()
    {
        print(Mathf.Lerp(0, 10, 0.7f));
        print(Vector2.Lerp(a, b, 0.7f));

        myColor = Color.Lerp(red, blue, 0.5f);
    }
}
