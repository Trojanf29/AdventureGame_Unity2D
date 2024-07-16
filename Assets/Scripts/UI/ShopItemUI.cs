using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public Text priceText;
    public Image hud;
    public Button btn;
    private ShopItem item;

    public void UpdateUI(ShopItem newItem, int shopItemId)
    {
        if (newItem == null) return;

        item = newItem;

        // Cập nhật hình ảnh của vật phẩm
        if (hud)
            hud.sprite = item.hud;

        // Hiển thị giá của sản phẩm
        if (priceText)
            priceText.text = item.price.ToString();

        // Xóa sự kiện cũ trước khi gán sự kiện mới
        if (btn)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => OnItemClick(shopItemId));
        }
    }

    private void OnItemClick(int itemId)
    {
        if (Pref.Score >= item.price)
        {
            Pref.Score -= item.price;
            var player = FindObjectOfType<PlayerHealth>();
            if (player != null)
            {
                player.IncreaseHealth(1); // Tăng 1 máu, bạn có thể điều chỉnh số lượng máu tùy theo item.
                player.UpdateHealthUI();
            }
            Debug.Log("Item purchased: " + itemId);
        }
        else
        {
            Debug.Log("Not enough score to purchase the item.");
        }
    }
}
