using UnityEngine;

public class NpcHints : MonoBehaviour
{
    public Transform player;
    public float talkDistance = 3f;

    private bool hasSpoken = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (!hasSpoken && distance < talkDistance)
        {
            hasSpoken = true;
            Debug.Log("Çýkýþ noktasýný bulmak için beni takip et!");
        }
    }
}
