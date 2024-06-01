using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gift : MonoBehaviour
{
    public GameObject imageToShow; // Kéo và thả GameObject chứa hình ảnh vào đây trong Inspector
    private bool gameStopped = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra va chạm với đối tượng có tag là "Gift"
        if (other.gameObject.CompareTag("Gift"))
        {
            // Phá hủy đối tượng hiện tại
            Destroy(other.gameObject);

            // Tạm dừng trò chơi và hiển thị hình ảnh trong 10 giây
            StartCoroutine(PauseGameAndShowImageForSeconds(10f));
        }
    }

    IEnumerator PauseGameAndShowImageForSeconds(float seconds)
    {
        // Tạm dừng trò chơi
        Time.timeScale = 0f;

        // Kích hoạt hình ảnh để hiển thị
        imageToShow.SetActive(true);

        // Chờ trong số giây đã chỉ định
        yield return new WaitForSecondsRealtime(seconds);

        // Vô hiệu hóa hình ảnh và khôi phục trạng thái trò chơi
        imageToShow.SetActive(false);
        Time.timeScale = 1f;
    }
}
