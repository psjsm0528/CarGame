using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float forwardSpeed = 10f;   // 앞으로 이동 속도
    public float sidewaysSpeed = 5f;   // 좌우 이동 속도

    void Update()
    {
        // ✅ 자동차는 앞으로 계속 이동
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // ✅ 좌우 입력 받기 (A = -1, D = +1)
        float h = Input.GetAxisRaw("Horizontal");
        // A키 → h = -1
        // D키 → h = +1

        // ✅ 좌우 이동 적용
        transform.Translate(Vector3.right * h * sidewaysSpeed * Time.deltaTime);
    }
}
