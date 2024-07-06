using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private int direction = 1;                          // 1: to the right

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0, 2) == 0 ? 1 : -1;

        if (direction > 0)
            Flip();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        if ((direction < 0 && transform.localScale.x < 0) || (direction > 0 && transform.localScale.x > 0))
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
