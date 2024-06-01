using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private int direction = 1; // Hướng di chuyển: 1 là qua phải, -1 là qua trái

    // Start is called before the first frame update
    void Start()
    {
        // Random hướng ban đầu, 0 là qua trái, 1 là qua phải
        direction = Random.Range(0, 2) == 0 ? 1 : -1;

        // Flip prefab nếu đi từ trái qua phải
        if (direction > 0)
            Flip();
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển prefab
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        // Flip prefab nếu thay đổi hướng
        if ((direction < 0 && transform.localScale.x < 0) || (direction > 0 && transform.localScale.x > 0))
            Flip();
    }

    // Hàm flip prefab
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
