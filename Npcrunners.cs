using UnityEngine;

public class Npcrunner : MonoBehaviour
{
    public Transform player;
    public Transform koseNoktasi; // YENÝ: Parkýn etrafýndan dolanacaðý köþe
    public Transform asilHedef;   // ESKÝ: Asýl gitmesi gereken son nokta
    public Animator anim;

    public float runSpeed = 4f;
    public float triggerDistance = 5f;
    public float stopDistance = 0.5f;

    private bool isRunning = false;
    private bool reachedTarget = false;

    // NPC'nin o an takip ettiði nokta
    private Transform suAnkiHedef;

    void Start()
    {
        // Oyun baþladýðýnda NPC'nin ilk hedefi parký teðet geçeceði köþe noktasý olsun
        suAnkiHedef = koseNoktasi;
    }

    void Update()
    {
        if (player == null || suAnkiHedef == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 1. TETÝKLENME (Oyuncu yaklaþýnca)
        if (!isRunning && !reachedTarget && distanceToPlayer < triggerDistance)
        {
            isRunning = true;
            if (anim != null) anim.SetBool("isRunning", true);
        }

        // 2. KOÞMA SÜRECÝ
        if (isRunning && !reachedTarget)
        {
            // O anki hedefe doðru yüzünü dön (Yukarý bakmasýný engelle)
            Vector3 targetDir = suAnkiHedef.position - transform.position;
            targetDir.y = 0;

            if (targetDir != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            }

            // O anki hedefe doðru ilerle
            transform.position = Vector3.MoveTowards(
                transform.position,
                suAnkiHedef.position,
                runSpeed * Time.deltaTime
            );

            // 3. HEDEFE VARMA VE YENÝ YÖN BELÝRLEME
            float distToTarget = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                                                 new Vector2(suAnkiHedef.position.x, suAnkiHedef.position.z));

            // Eðer hedef noktasýna (köþeye veya sona) yaklaþtýysa:
            if (distToTarget < stopDistance)
            {
                // Eðer geldiðimiz yer "Köþe Noktasý" ise, yeni hedefi "Asýl Hedef" yap!
                if (suAnkiHedef == koseNoktasi)
                {
                    suAnkiHedef = asilHedef;
                }
                // Eðer geldiðimiz yer "Asýl Hedef" ise dur.
                else if (suAnkiHedef == asilHedef)
                {
                    reachedTarget = true;
                    isRunning = false;
                    if (anim != null) anim.SetBool("isRunning", false);
                    Debug.Log("Çýkýþ noktasýna vardýnn!");
                }
            }
        }
    }
}