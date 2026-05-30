using UnityEngine;

public class NewEmptyCSharpScript : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float jumpForce = 5f;

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;

    // Kamerayı referans almak için bir değişken ekliyoruz
    private Transform cameraTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Ana kameranın Transform bileşenini alıyoruz
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
        else
        {
            Debug.LogError("Sahnede 'MainCamera' etiketine sahip bir kamera bulunamadı!");
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 1. Kameranın ileri ve sağ yönlerini al
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // 2. Y eksenini sıfırla ki karakter kameraya bakarak havaya uçmaya çalışmasın
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // 3. Hareketi kameranın yönüne göre hesapla
        Vector3 move = (camForward * v + camRight * h).normalized;

        // Yürüme kontrolü
        bool isWalking = move.magnitude > 0.1f;
        animator.SetBool("isWalking", isWalking);

        // Koşma kontrolü (Shift basılıysa)
        bool isRunning = isWalking && Input.GetKey(KeyCode.LeftShift);
        animator.SetBool("isRunning", isRunning);

        float speed = isRunning ? runSpeed : walkSpeed;

        // Hareket (Artık kameraya göre hesaplanan move vektörünü kullanıyoruz)
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        // Karakterin yönünü çevir
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Zıplama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Zemin kontrolü
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }
}