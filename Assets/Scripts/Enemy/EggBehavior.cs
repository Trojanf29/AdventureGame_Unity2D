using System.Collections;
using UnityEngine;

public class EggTime : MonoBehaviour
{
    [SerializeField]
    private float eggLifetime = 2f;

    void Start()
    {
        StartCoroutine(DestroyEggAfterTime());
    }

    IEnumerator DestroyEggAfterTime()
    {
        yield return new WaitForSeconds(eggLifetime);

        Destroy(gameObject);
    }
}
