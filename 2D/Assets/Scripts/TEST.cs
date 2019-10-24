using UnityEngine;

public class TEST : MonoBehaviour
{
    private Transform cam;

    private void Update()
    {
        Quaternion camRot = new Quaternion(0, cam.rotation.y, 0, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, camRot, 0.9f);
    }
}
