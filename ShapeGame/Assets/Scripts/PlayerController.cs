using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public string targetTag = "";


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        isDragging = true;
                        offset = transform.position - touchPos;
                    }
                    break;
                case TouchPhase.Moved:
                    if (isDragging) transform.position = touchPos + offset;
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    break;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                isDragging = true;
                offset = transform.position - mousePos;
            }
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos + offset;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            transform.position = other.transform.position;
            isDragging = false;
            
            Debug.Log("Touched");
        }
    }
}