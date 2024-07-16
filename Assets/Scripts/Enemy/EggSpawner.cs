using System.Collections;
using UnityEngine;

public class EnemyEgg : MonoBehaviour
{
    [SerializeField]
    private GameObject eggPrefab;

    void Start()
    {
        StartCoroutine(DropEgg());
    }

    IEnumerator DropEgg()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 2f));

        Vector3 eggPosition = transform.position - new Vector3(0f, 0.7f, 0f);
        Instantiate(eggPrefab, eggPosition, Quaternion.identity);
    }
}
