using UnityEngine;

public class YolBasi : MonoBehaviour
{
    private Vector3 baslangicNoktasi;
    private CharacterController characterController;

    void Start()
    {
        // Karakterin oyuna baþladýðý ilk noktayý hafýzaya alýyoruz
        baslangicNoktasi = transform.position;

        // PlayerArmature üzerindeki CharacterController'ý buluyoruz
        characterController = GetComponent<CharacterController>();
    }

    // Mantardaki Collider "Is Trigger" olduðu için OnTriggerEnter kullanmalýyýz
    private void OnTriggerEnter(Collider other)
    {
        // Eðer içinden geçtiðimiz objenin tag'i "Engel" ise
        if (other.CompareTag("Engel1"))
        {
            // CharacterController'ý geçici olarak kapat (Iþýnlanma hilesi)
            characterController.enabled = false;

            // Karakteri baþlangýç noktasýna ýþýnla
            transform.position = baslangicNoktasi;

            // CharacterController'ý geri aç
            characterController.enabled = true;
        }
    }
}