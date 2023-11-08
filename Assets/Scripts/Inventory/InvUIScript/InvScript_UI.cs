using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvScript_UI : MonoBehaviour
{
    [SerializeField] private Image itemUISprite;
    [SerializeField] private TextMeshProUGUI itemUICount;
    [SerializeField] private InvItemSlot selectedUISlot;
    public Button slotButton;
    public InvItemSlot assignedUISlot => selectedUISlot;
    public InvScript_UIDisplay ParentDisplay {get; private set;}

    private void Awake(){
        EmptyUISlot();
        slotButton = GetComponent<Button>();
        slotButton?.onClick.AddListener(OnUISlotButtonClick);
        ParentDisplay = transform.parent.GetComponent<InvScript_UIDisplay>();
    }

    public void InSlot(InvItemSlot slot){
        selectedUISlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InvItemSlot slot){
        if(slot.itemData2 != null){
            if(slot.itemData2.itemIcon != null){
                itemUISprite.sprite = slot.itemData2.itemIcon;
                itemUISprite.color = Color.white;
                if(slot.itemStackSize2 > 1){
                    itemUICount.text = slot.itemStackSize2.ToString();
                }
                else{
                    itemUICount.text = "";
                }
            }
        }
        else{
            EmptyUISlot();
        }
    }

    public void UpdateUISlot(){
        if (selectedUISlot != null) UpdateUISlot(selectedUISlot);
    }

    public void EmptyUISlot(){
        selectedUISlot?.EmptyItemSlot();
        itemUISprite.sprite = null;
        itemUISprite.color = Color.clear;
        itemUICount.text = "";   
    }

    public void OnUISlotButtonClick(){
        ParentDisplay?.SlotClicked(this);
    }
}
