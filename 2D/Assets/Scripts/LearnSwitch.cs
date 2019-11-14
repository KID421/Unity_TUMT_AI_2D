using UnityEngine;

public class LearnSwitch : MonoBehaviour
{
    public string myColor = "黑色";

    public enum season
    {
        spring, summer, fall, winter
    }

    public season _season = season.fall;

    private void Start()
    {
        if (myColor == "黑色")
        {
            print("玩家輸入的是黑色");
        }
        else if (myColor == "紅色")
        {
            print("玩家輸入的是紅色");
        }

        switch (myColor)
        {
            case "黑色":
                print("玩家輸入的是黑色");
                break;
            case "紅色":
                print("玩家輸入的是紅色");
                break;
            default:
                print("查無此顏色");
                break;
        }

        switch (_season)
        {
            case season.spring:
                print("春天");
                break;
            case season.summer:
                print("夏天");
                break;
            case season.fall:
                print("秋天");
                break;
            case season.winter:
                print("冬天");
                break;
        }
    }
}
