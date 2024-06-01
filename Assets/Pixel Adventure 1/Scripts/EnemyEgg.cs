using System.Collections;
using UnityEngine;

public class EnemyEgg : MonoBehaviour
{
    [SerializeField] private GameObject eggPrefab;

    void Start()
    {
        StartCoroutine(DropEgg());
    }

    IEnumerator DropEgg()
    {
        // Chờ một khoảng thời gian ngẫu nhiên trong khoảng từ 1.5 đến 2 giây
        yield return new WaitForSeconds(Random.Range(1.5f, 2f));

        // Tạo egg tại vị trí hiện tại với một khoảng cách nhất định từ trên xuống dưới
        Vector3 eggPosition = transform.position - new Vector3(0f, 0.7f, 0f);
        GameObject newEgg = Instantiate(eggPrefab, eggPosition, Quaternion.identity);

    
    }
}
