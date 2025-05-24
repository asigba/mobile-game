using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

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
        if (other.CompareTag("goal"))
        {


            Vector2 playerCenter = new Vector2(transform.position.x, transform.position.y);
            Vector2 goalCenter = new Vector2(other.transform.position.x, other.transform.position.y);

            float goalRadius = other.GetComponent<CircleCollider2D>().bounds.extents.x;
            float snapThreshold = goalRadius * 0.5f; // 10% of goal's radius

            float distance = Vector2.Distance(playerCenter, goalCenter);
            
            if (distance <= snapThreshold)
            {
                transform.position = other.transform.position;
                isDragging = false;
            }
            
            Debug.Log("Touched");
        }
    }
}