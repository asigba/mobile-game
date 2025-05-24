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
            }      
            
        }
    }
}