using UnityEngine;

public class LearnSwitch : MonoBehaviour
{
    public string myColor = "黑色";

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
        }
    }
}
