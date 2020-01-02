using UnityEngine;

namespace KID
{
    public class CameraControl : MonoBehaviour
    {
        [Header("速度"), Range(0, 10)]
        public float speed = 3;

        private Transform target;

        private void Start()
        {
            target = GameObject.Find("狐狸").transform;
        }

        // 延遲更新：Update 之後執行 - 攝影機追蹤、物件追蹤
        private void LateUpdate()
        {
            Vector3 cam = transform.position;
            Vector3 tar = target.position;
            tar.z = -10;
            transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
        }
    }
}

