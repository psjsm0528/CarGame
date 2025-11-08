using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // 따라갈 차량
    public Vector3 offset = new Vector3(0, 5, -10); // 카메라 위치 오프셋
    public float rotationSpeed = 5f;  // 마우스 회전 속도

    private float yaw = 0f;           // 좌우 회전값
    private float pitch = 20f;        // 상하 회전값 (초기값)

    void LateUpdate()
    {
        if (target == null) return;

        // 우클릭을 누르고 있을 때만 마우스로 카메라 회전
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            pitch = Mathf.Clamp(pitch, 5f, 45f); // 카메라 위아래 제한
        }

        // 카메라 회전
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position);
    }
}
