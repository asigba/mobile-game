using UnityEngine;
using UnityEngine.Playables;


public class Goal : MonoBehaviour
{
    public string targetTag = "";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            other.transform.position = transform.position;

            PlayerController pl = other.GetComponent<PlayerController>();
            if (pl != null)
            {
                pl.isDragging = false;

                // StartCoroutine(RespawnAfterDelay(other.gameObject, 2f));
                // StartCoroutine(RespawnAfterDelay(gameObject, 2f));

                StartCoroutine(GetComponent<Voicelines>().PlayVoiceline());
            }

        }
    }

    private System.Collections.IEnumerator RespawnAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);

        Respawnable respawnObj = obj.GetComponent<Respawnable>();
        Respawnable respawnthis = gameObject.GetComponent<Respawnable>();
        if (respawnObj != null) respawnObj.Respawn();
        if (respawnthis != null) respawnthis.Respawn();
        obj.SetActive(true);
        gameObject.SetActive(true);



    }
}