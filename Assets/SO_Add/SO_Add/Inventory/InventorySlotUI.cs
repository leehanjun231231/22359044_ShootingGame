using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    public Image iconImage;
    public TMP_Text countText;

    private InventoryUI inventoryUI;
    private List<InventoryItem> itemList;
    private int index;

    // 아이콘의 원래 위치를 기억할 변수 추가
    private Vector2 originalIconPosition;

    public void SetSlot(InventoryUI inventoryUI, List<InventoryItem> itemList, int index)
    {
        this.inventoryUI = inventoryUI;
        this.itemList = itemList;
        this.index = index;

        InventoryItem item = itemList[index];

        // 아이템이 존재할 경우 UI 갱신
        if (item != null && item.data != null)
        {
            iconImage.sprite = item.data.icon;
            iconImage.gameObject.SetActive(true);
            countText.text = item.count > 1 ? item.count.ToString() : "";
        }
        else // 빈 슬롯일 경우
        {
            iconImage.sprite = null;
            iconImage.gameObject.SetActive(false);
            countText.text = "";
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 아이템이 없으면 return
        if (itemList[index] == null || itemList[index].data == null)
        {
            eventData.pointerDrag = null; // 드래그 취소
            return;
        }

        // 원래 위치 저장 및 아이콘 raycast 끄기
        originalIconPosition = iconImage.rectTransform.anchoredPosition;
        iconImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 마우스 이동량만큼 아이콘 이동
        iconImage.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 아이콘을 원위치하고 raycast 다시 켜기
        iconImage.rectTransform.anchoredPosition = originalIconPosition;
        iconImage.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // 드래그 시작 슬롯을 찾아 PlayerInventory.MoveItem() 호출
        if (eventData.pointerDrag != null)
        {
            InventorySlotUI dragSlot = eventData.pointerDrag.GetComponent<InventorySlotUI>();
            if (dragSlot != null)
            {
                // 데이터 스왑
                PlayerInventory.Instance.MoveItem(dragSlot.itemList, dragSlot.index, this.itemList, this.index);
                // UI 즉시 새로고침
                inventoryUI.Refresh();
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 마우스 우클릭을 감지
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            InventoryItem item = itemList[index];

            // 인벤에 아이템이 있고, 그게 소모품 아이템이라면?
            if (item != null && item.data != null && item.data.itemType == ItemType.Consumable)
            {
                Debug.Log(item.data.itemName + " 아이템을 사용했습니다.");

                // 아이템 개수 1개 감소
                item.count--;

                // 개수가 0이 되면 슬롯 비우기
                if (item.count <= 0)
                {
                    itemList[index] = null;
                }

                // UI 새로고침 하여 정보 최신화
                inventoryUI.Refresh();
            }
        }
    }

}