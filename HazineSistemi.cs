using UnityEngine;

public class HazineSistemi : MonoBehaviour
{
    [Header("Sandýk Modelleri")]
    public GameObject kapaliSandik;
    public GameObject acikSandik;

    [Header("Arayüz (UI)")]
    public GameObject mektupUI;

    private void OnTriggerEnter(Collider other)
    {
        // Çarptýðýmýz objenin ismini küçültüp alýyoruz
        string objeIsmi = other.gameObject.name.ToLower();

        // EÐER ÇARPTIÐIMIZ OBJENÝN ADINDA "SANDÝK" GEÇÝYORSA:
        if (objeIsmi.Contains("sandik"))
        {
            // 1. Kapalý sandýðý gizle, açýk sandýðý göster
            if (kapaliSandik != null) kapaliSandik.SetActive(false);
            if (acikSandik != null) acikSandik.SetActive(true);

            // 2. Mektubu ekranda görünür yap
            if (mektupUI != null)
            {
                mektupUI.SetActive(true);
                Debug.Log("Sandýk açýldý ve mektup ekrana geldi!");
            }
            else
            {
                Debug.LogWarning("DÝKKAT: Inspector'da Mektup UI kýsmý boþ kalmýþ!");
            }
        }
    }
}