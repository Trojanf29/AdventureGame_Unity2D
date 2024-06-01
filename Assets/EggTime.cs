using System.Collections;
using UnityEngine;

public class EggTime : MonoBehaviour
{
    [SerializeField] private float eggLifetime = 2f; // Thời gian tồn tại của egg

    void Start()
    {
        StartCoroutine(DestroyEggAfterTime());
    }

    IEnumerator DestroyEggAfterTime()
    {
        // Chờ trong một khoảng thời gian bằng thời gian tồn tại của egg
        yield return new WaitForSeconds(eggLifetime);

        // Sau khi chờ đủ thời gian, hủy bỏ egg
        Destroy(gameObject);
    }
}
