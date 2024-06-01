using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            // Lấy tham chiếu đến PlayerMovement component
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            collectSoundEffect.Play();

            // Kiểm tra nếu đã lấy được tham chiếu
            if (playerMovement != null)
            {
                // Tạo một màu ngẫu nhiên và truyền vào OnCherryCollected
                Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                playerMovement.OnCherryCollected(randomColor);
            }
                        

            // Hủy đối tượng cherry
            Destroy(collision.gameObject);
            cherries++;
           cherriesText.text = "Cherries: " + cherries;
        }
    }
}
