using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    public string targetTag = "";
    private Collider2D dragCollider;
    private Collider2D triggerColliders;


    void Start()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach (var col in colliders)
        {
            if (col.isTrigger) triggerColliders = col;
            else dragCollider = col;
        }
    }

    void Update()
    {
        // Touchscreen on iOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (dragCollider == Physics2D.OverlapPoint(touchPos))
                    {
                        isDragging = true;
                        offset = transform.position - touchPos;
                        StartCoroutine(GetComponent<Voicelines>().PlayVoiceline());
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
        
        // Mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (dragCollider == Physics2D.OverlapPoint(mousePos))
            {
                isDragging = true;
                offset = transform.position - mousePos;
                StartCoroutine(GetComponent<Voicelines>().PlayVoiceline());
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
}