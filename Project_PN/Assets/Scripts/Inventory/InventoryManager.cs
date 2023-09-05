using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    void Swap(uint slot1, uint slot2)
    {
        uint tmp;

        tmp = slot1;
        slot1 = slot2;
        slot2 = tmp;
        
    }
    [Header("아이템 정보 표시 UI")]
    [SerializeField] RectTransform ItemInfo;

    [SerializeField] KeyCode SwapKey;

    

    public static uint slot1_id = 301;
    public static uint slot2_id = 0;

    public static uint slot3_id = 201;
    public static uint slot4_id;
    // Start is called before the first frame update
    private void Awake()
    {
        slot4_id = slot1_id;
    }
    void Start()
    {
        
        ItemDataManager.GetInstance();
        Invoke("Setting", 0.1f);
    }

    void Setting()
    {
       
        W_Slot1.W1_ReloadID();
        W_Slot2.W2_ReloadID();
        W_Slot4.W4_ReloadID();
        
        W_Slot1.W1_ReloadData();
        W_Slot2.W2_ReloadData();
        W_Slot4.W4_ReloadData();
    }

    // Update is called once per frame
    void Update()
    {
        slot4_id = slot1_id;
        MousePosition();
        WeaponChange();
    }

    void WeaponChange()
    {
        if(Input.GetKeyDown(SwapKey) && InventoryManager.slot2_id != 0 && !PlayerMovement.SkillUsing && !PlayerMovement.WeaponChanging)
        {
          
            uint tmp;

            tmp = slot1_id;
            slot1_id = slot2_id;
            slot2_id = tmp;

            if(W_Slot1.MouseOverlaping)
            {
                W_Slot1.W1_ReloadInfoData();
                Debug.Log("info1");
            }
            if (W_Slot2.MouseOverlaping)
            {
                W_Slot2.W2_ReloadInfoData();
                Debug.Log("info2");
            }
            if (W_Slot3.MouseOverlaping)
            {
                W_Slot3.W3_ReloadInfoData();
                Debug.Log("info3");
            }
            if(W_Slot4.MouseOverlaping)
            {
                W_Slot4.W4_ReloadInfoData();
                Debug.Log("info4");
            }
            Setting();
        }
    }

    void DataReloading()
    {
        Slot.ReloadInfoData();
        Slot.ReloadData();
    }
    void MousePosition()
    { 
        Vector2 mousePos = Input.mousePosition;
        if(ItemInfo.anchoredPosition.x <= 743.724f)
        {
            ItemInfo.position = mousePos + (new Vector2(200, 80));
        }
        else
        {
            ItemInfo.position = (new Vector2(ItemInfo.position.x,mousePos.y + 80));
            if(mousePos.x <= 1503.72f)
            {
                ItemInfo.position = mousePos + (new Vector2(200, 80));
            }
        }
       
        
    }
   
}
