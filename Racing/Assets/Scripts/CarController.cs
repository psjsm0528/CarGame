using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;       // 전진 속도
    public float turnSpeed = 50f;   // 회전 속도

    void Update()
    {
        // 전진/후진
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);

        // 좌우 회전
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * turn);
    }
}
