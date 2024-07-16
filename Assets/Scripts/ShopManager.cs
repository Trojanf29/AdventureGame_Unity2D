using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] items; // Danh sách các mặt hàng shop
    public Transform gridRoot; // Transform chứa các item UI
    public GameObject itemUIPrefab; // Prefab của ShopItemUI

    private void Start()
    {
        LoadShopItems();
    }

    private void LoadShopItems()
    {
        // Kiểm tra nếu danh sách items hoặc gridRoot hoặc itemUIPrefab bị null
        if (items == null || items.Length == 0 || gridRoot == null || itemUIPrefab == null)
            return;

        // Xóa các item cũ trong gridRoot trước khi cập nhật
        foreach (Transform child in gridRoot)
        {
            Destroy(child.gameObject);
        }

        // Duyệt qua tất cả các item trong danh sách
        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i];

            if (item != null)
            {
                // Instantiate một bản sao của itemUIPrefab
                var itemUIClone = Instantiate(itemUIPrefab, gridRoot);

                // Đặt vị trí và scale của itemUIClone
                itemUIClone.transform.localScale = Vector3.one;

                // Cập nhật UI của item
                var shopItemUI = itemUIClone.GetComponent<ShopItemUI>();
                if (shopItemUI != null)
                {
                    shopItemUI.UpdateUI(item, i);
                }
            }
        }
    }
}

[System.Serializable]
public class ShopItem
{
    public int price;
    public Sprite hud;
    public GameObject pb;
}
