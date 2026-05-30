using UnityEngine;

public class DonmeEfekti : MonoBehaviour
{
    void Update()
    {
        // Altýný her karede kendi ekseninde döndürür
        transform.Rotate(new Vector3(0, 100 * Time.deltaTime, 0));
    }
}