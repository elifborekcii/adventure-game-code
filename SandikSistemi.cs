using UnityEngine;

public class SandikSistemi : MonoBehaviour
{
    public GameObject kapaliSandik;
    public GameObject acikSandik;

    // Mektup arayüzümüz için yeni eklediðimiz boþluk
    public GameObject mektupUI;

    public int gerekenKristal = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Buraya yine kendi kristal kontrol þartýný eklemelisin
            SandigiAc();
        }
    }

    void SandigiAc()
    {
        kapaliSandik.SetActive(false);
        acikSandik.SetActive(true);

        // Sandýk açýldýðýnda mektubu da ekranda görünür yap
        if (mektupUI != null)
        {
            mektupUI.SetActive(true);
        }
    }
}