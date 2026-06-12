using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public int bagSlotCount = 12;
    public int equipSlotCount = 3;

    public List<InventoryItem> bagItems = new List<InventoryItem>();
    public List<InventoryItem> equipItems = new List<InventoryItem>();

    private void Awake()
    {
        Instance = this;
        // bagItems와 equipItems를 슬롯 수만큼 null로 채우기
        bagItems.Clear();
        equipItems.Clear();

        FillEmptySlots(bagItems, bagSlotCount);
        FillEmptySlots(equipItems, equipSlotCount);

    }

    public bool AddItem(ItemData itemData, int count = 1)
    {
        if (itemData == null || count <= 0) return false;

        // 1. 같은 아이템이 있으면 개수 누적
        if (itemData.canStack)
        {
            for (int i = 0; i < bagItems.Count; i++)
            {
                InventoryItem item = bagItems[i];

                if (item != null && item.data == itemData && item.count < itemData.maxStack)
                {
                    int addCount = Mathf.Min(count, itemData.maxStack - item.count);
                    item.count += addCount;
                    count -= addCount;

                    if (count <= 0)
                    {
                        Debug.Log(itemData.itemName + " 스택 추가 완료");
                        return true; // 아이템을 모두 넣었을 때만 종료
                    }
                }
            }
        }

        // 2. 빈 칸을 찾아 새 아이템 넣기 (위에서 남은 count 처리)
        for (int i = 0; i < bagItems.Count; i++)
        {
            if (bagItems[i] == null || bagItems[i].data == null)
            {
                // 빈 칸에 넣을 수 있는 만큼 넣기
                int addCount = itemData.canStack ? Mathf.Min(count, itemData.maxStack) : 1;
                bagItems[i] = new InventoryItem(itemData, addCount);
                count -= addCount;

                Debug.Log(itemData.itemName + " 새 슬롯에 추가 성공");

                if (count <= 0)
                {
                    return true; // 성공적으로 다 넣었으므로 true 반환 (기존 false 수정)
                }
            }
        }

        // 3. 루프를 다 돌았는데도 count가 남았다면 가방이 꽉 찬 것임 (컴파일 에러 해결)
        Debug.Log("가방이 꽉 찼습니다. 남은 개수: " + count);
        return false;
    }

    public void MoveItem(List<InventoryItem> fromList, int fromIndex, List<InventoryItem> toList, int toIndex)
    {
        // from 슬롯과 to 슬롯의 아이템을 서로 바꾸기 (Swap)
        InventoryItem temp = fromList[fromIndex];
        fromList[fromIndex] = toList[toIndex];
        toList[toIndex] = temp;
    }

    private void FillEmptySlots(List<InventoryItem> list, int slotCount)
    {
        while (list.Count < slotCount)
        {
            list.Add(null);
        }
    }
}
