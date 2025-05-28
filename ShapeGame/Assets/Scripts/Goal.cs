using System;
using UnityEngine;
using UnityEngine.Playables;


public class Goal : MonoBehaviour
{
    public string targetTag = "";

    private System.Collections.IEnumerator OnTriggerEnter2D(Collider2D other)
    {       
        TypeIdentifier otherType = other.GetComponent<TypeIdentifier>();       

        if (otherType.type == targetTag)
        {
            other.transform.position = transform.position;

            PlayerController pl = other.GetComponent<PlayerController>();
            if (pl != null)
            {
                pl.isDragging = false;

                // StartCoroutine(RespawnAfterDelay(other.gameObject, 2.5f));
                // StartCoroutine(RespawnAfterDelay(gameObject, 2.5f));

                StartCoroutine(GetComponent<Voicelines>().PlayVoiceline());

                yield return new WaitForSeconds(5f);

                Destroy(other.gameObject);
                Destroy(gameObject);
            }

        }
    }

    // private System.Collections.IEnumerator RespawnAfterDelay(GameObject obj, float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     obj.SetActive(false);
    //     gameObject.SetActive(false);       

    //     Respawnable respawnObj = obj.GetComponent<Respawnable>();
    //     Respawnable respawnthis = gameObject.GetComponent<Respawnable>();
    //     Destroy(obj);
    //     Destroy(gameObject);
    //     if (respawnObj != null) respawnObj.Respawn();
    //     if (respawnthis != null) respawnthis.Respawn();
    // }
}