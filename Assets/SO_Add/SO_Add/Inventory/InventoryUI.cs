using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public InventorySlotUI[] bagSlots;
    public InventorySlotUI[] equipSlots;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    public void Toggle()
    {
        // 패널이 현재 켜져있는지 확인
        bool isActive = inventoryPanel.activeSelf;

        // 상태 반전 (켜져있으면 끄고, 꺼져있으면 켜기)
        inventoryPanel.SetActive(!isActive);

        if (!isActive)
        {
            // 1. 인벤토리가 열릴 때
            Refresh();
            Time.timeScale = 0f; // 게임 일시정지
        }
        else
        {
            // 2. 인벤토리가 닫힐 때
            Time.timeScale = 1f; // 게임 다시 재게
        }
    }

    public void Refresh()
    {
        // bagSlots에 PlayerInventory의 가방 리스트 연결
        for (int i = 0; i < bagSlots.Length; i++)
        {
            if (i < PlayerInventory.Instance.bagItems.Count)
            {
                bagSlots[i].SetSlot(this, PlayerInventory.Instance.bagItems, i);
            }
        }

        // equipSlots에 PlayerInventory의 장비 리스트 연결
        for (int i = 0; i < equipSlots.Length; i++)
        {
            if (i < PlayerInventory.Instance.equipItems.Count)
            {
                equipSlots[i].SetSlot(this, PlayerInventory.Instance.equipItems, i);
            }
        }
    }
}
