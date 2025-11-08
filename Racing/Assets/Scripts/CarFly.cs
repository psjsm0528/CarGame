using UnityEngine;

public class CarFly : MonoBehaviour
{
    public Rigidbody rb;
    public float flyForce = 10f; // ���� �ڱ�ġ�� ��
    public float flyDuration = 2f; // ���߿� �� �ִ� �ð�

    private bool isFlying = false;
    private float flyTimer = 0f;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isFlying)
        {
            flyTimer -= Time.deltaTime;
            if (flyTimer <= 0f)
            {
                isFlying = false;
                rb.useGravity = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Fly();
        }
    }

    void Fly()
    {
        isFlying = true;
        flyTimer = flyDuration;

        rb.useGravity = false;

        // y�ӵ��� ���� �����Ͽ� ��� ����
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, flyForce, rb.linearVelocity.z);
    }
}
