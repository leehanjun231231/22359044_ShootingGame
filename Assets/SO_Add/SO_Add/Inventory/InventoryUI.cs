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
        // 패널 열기/닫기
        bool isActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isActive);

        // 열릴 때 Refresh() 호출
        if (!isActive)
        {
            Refresh();
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
