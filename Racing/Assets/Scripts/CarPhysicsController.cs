using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarPhysicsController : MonoBehaviour
{
    [Header("Car Settings")]
    public float acceleration = 800f;     // ���� ���ӵ�
    public float reverseForce = 400f;     // ���� ���ӵ�
    public float turnSpeed = 100f;        // ȸ�� �ӵ�
    public float maxSpeed = 20f;          // �ִ� �ӵ�

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0); // ���������� �߽� ���߱�
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");   // W/S Ű
        float turnInput = Input.GetAxis("Horizontal"); // A/D Ű

        // ���� �ӵ�
        float currentSpeed = rb.linearVelocity.magnitude;

        // ���� / ����
        if (moveInput > 0 && currentSpeed < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput * acceleration * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        else if (moveInput < 0 && currentSpeed < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput * reverseForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

        // ȸ�� (�ӵ� ���� ����)
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            float turn = turnInput * turnSpeed * Time.fixedDeltaTime * Mathf.Sign(moveInput);
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}
