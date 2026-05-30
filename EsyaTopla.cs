using UnityEngine;

public class EsyaTopla : MonoBehaviour
{
    // Bu deðiþkeni tanýmladýktan sonra Unity'e dönüp 
    // coin_2 sesini Inspector'dan buraya sürüklemelisin.
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        // Çarpan obje oyuncu mu diye kontrol ediyoruz (Karakterinin Tag'i "Player" olmalý)
        if (other.CompareTag("Player"))

            GecisKontrol.toplananParca += 1;
        {
            // Sesi elmasýn olduðu konumda anlýk olarak oluþtur ve çal
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Elmasý sahneden yok et (Ses silinmeyecek çünkü PlayClipAtPoint ayrý bir kaynak oluþturur)
            Destroy(gameObject);
        }
    }
}