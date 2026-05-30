using UnityEngine;

public class BasaDonme : MonoBehaviour
{
    private Vector3 baslangicNoktasi;
    private CharacterController characterController;

    void Start()
    {
        // Karakterin oyuna başladığı ilk noktayı hafızaya alıyoruz
        baslangicNoktasi = transform.position;

        // PlayerArmature üzerindeki CharacterController'ı buluyoruz
        characterController = GetComponent<CharacterController>();
    }

    // Mantardaki Collider "Is Trigger" olduğu için OnTriggerEnter kullanmalıyız
    private void OnTriggerEnter(Collider other)
    {
        // Eğer içinden geçtiğimiz objenin tag'i "Engel" ise
        if (other.CompareTag("Engel"))
        {
            // CharacterController'ı geçici olarak kapat (Işınlanma hilesi)
            characterController.enabled = false;

            // Karakteri başlangıç noktasına ışınla
            transform.position = baslangicNoktasi;

            // CharacterController'ı geri aç
            characterController.enabled = true;
        }
    }
}