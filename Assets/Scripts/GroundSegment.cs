using UnityEngine;

public class GroundSegment : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private BoxCollider2D boxCollider2D;
    private float segmentWidth;
    private int segmentCount = 3;

    private void Start()
    {
        segmentWidth = boxCollider2D.bounds.size.x;
    }
    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        GroundSwitch();
    }

    private void GroundSwitch()
    {
        if(transform.position.x < -segmentWidth)
        {
            transform.position += new Vector3(segmentWidth * segmentCount, 0, 0);
        }
    }
}
