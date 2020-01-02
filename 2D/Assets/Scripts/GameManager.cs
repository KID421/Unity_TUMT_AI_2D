using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API

namespace KID
{
    public class GameManager : MonoBehaviour
    {
        public void Replay()
        {
            //Application.LoadLevel("遊戲");    // 舊版 API
            SceneManager.LoadScene("遊戲");   // 新版 API
        }

        public void Quit()
        {
            Application.Quit(); // 應用程式.離開遊戲
        }
    }
}

