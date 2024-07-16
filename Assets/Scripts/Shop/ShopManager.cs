using UnityEngine;

public class ShopManager : MonoBehaviour
{
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

        Instantiate(shopItemPrefab, shopContent);
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
