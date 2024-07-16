using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.StatelessData.Enums;

public class ShopItemUI : MonoBehaviour
{
    public ShopItem Item;
    private const int Price = 1;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            OnItemClick();
        });
    }

    public void OnItemClick()
    {
        bool isPurchased = false;

        if (GameSessionHandler.CurrentProfile.Point >= Price)
        {
            if (Item == ShopItem.Health)
            {
                var player = FindObjectOfType<PlayerHealth>();
                if (player != null && player.currentHealth < player.startingHealth)
                {
                    player.IncreaseHealth(1);
                }
                isPurchased = true;
            }
        }

        if (isPurchased)
        {
            GameSessionHandler.CurrentProfile.Point -= Price;
            LevelHandler.Instance.UpdatePoint();
            GameSessionHandler.SaveSession();
        }

        Debug.Log(isPurchased ? "Item purchased" : "Cannot purchase this item");
    }
}