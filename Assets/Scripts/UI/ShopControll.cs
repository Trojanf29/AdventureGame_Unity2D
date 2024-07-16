using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControll : MonoBehaviour
{
    public GameObject shopDialog; // Kéo thả shopDialog vào đây trong Inspector

    void Start()
    {
        // Đảm bảo shopDialog ẩn khi bắt đầu game
        if (shopDialog != null)
        {
            shopDialog.SetActive(false);
        }
    }

    public void ShowShopDialog()
    {
        // Hiển thị shopDialog
        if (shopDialog != null)
        {
            shopDialog.SetActive(true);
        }
    }
    public void CloseShopDialog()
    {
        if (shopDialog != null)
        {
            shopDialog.SetActive(false);
        }
    }
   }
