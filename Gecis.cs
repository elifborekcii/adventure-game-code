using UnityEngine;
using UnityEngine.SceneManagement;

public class Gecis : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("bölüm2");
        }
    }
}