using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<ShopItem> shopItems; // Danh sách các mặt hàng shop
    public Transform shopContent; // Transform chứa các item UI
    public GameObject shopItemPrefab; // Prefab của ShopItemUI

    private void Start()
    {
        LoadShopItems();
    }

    private void LoadShopItems()
    {
        // Xóa tất cả các mặt hàng cũ trong shop
        foreach (Transform child in shopContent)
        {
            Destroy(child.gameObject);
        }

        // Khởi tạo các mặt hàng mới
        for (int i = 0; i < shopItems.Count; i++)
        {
            ShopItem item = shopItems[i];
            GameObject shopItemUIObject = Instantiate(shopItemPrefab, shopContent);
            //ShopItemUI shopItemUI = shopItemUIObject.GetComponent<ShopItemUI>();
            //shopItemUI.UpdateUI(item, i); // Sử dụng chỉ số i thay cho ID
        }
    }

    public void ShowShopDialog()
    {
        shopContent.parent.gameObject.SetActive(true);
        LoadShopItems(); // Cập nhật các mặt hàng mỗi khi mở shop
    }

    public void CloseShopDialog()
    {
        shopContent.parent.gameObject.SetActive(false);
    }
}
