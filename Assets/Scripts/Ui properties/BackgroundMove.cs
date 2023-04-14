using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float scrollSpeed = 1f;
    private float startPosition;
    private float spriteWidth;
    public GameObject playerCam;

    void Start()
    {
        startPosition = transform.position.x;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        float newPosition = Mathf.Repeat(Time.time * -scrollSpeed, spriteWidth);
        transform.position = new Vector2(startPosition + newPosition, transform.position.y);
    }
}