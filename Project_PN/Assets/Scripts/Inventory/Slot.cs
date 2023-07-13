using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using JetBrains.Annotations;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("아이템 정보 표시 UI")]
    [SerializeField] GameObject ItemInfo;

    [Header("아이템 ID")]
    [SerializeField] uint ItemID;

    [Header("슬롯 이미지")]
    Image ItemImage;

    [Header("Info")]
    [SerializeField] Text Item_Name;
    [SerializeField] Text Item_Stats;
    [SerializeField] Text Item_Desc;

    public static Action ReloadInfoData;

    public static Action ReloadData;

    public static Action ReloadID;
    
    public bool ItemEnable = false;
    // Start is called before the first frame update
    private void Awake()
    {
        ReloadInfoData = () => { InfoReload(); };

        ReloadData = () => { DataReload(); };

        ReloadID = () => { IDLoad(); };
        
    }
    void ResetText()
    {
        Item_Name.text = "";
        Item_Stats.text = "";
        Item_Desc.text = "";
    }
       
    
    void Start()
    {
        ResetText();
        IDLoad();
        if (gameObject.name == "Slot 1" && gameObject.tag == "SlotWeapon")
        {
            Debug.Log("Slot 1 Found");
            ItemImage = GameObject.Find("S1").GetComponent<Image>();
        }
        if (gameObject.name == "Slot 2" && gameObject.tag == "SlotWeapon")
        {
            Debug.Log("Slot 2 Found");
            ItemImage = GameObject.Find("S2").GetComponent<Image>();
        }
        if (gameObject.name == "Slot 3" && gameObject.tag == "SlotPotion")
        {
            Debug.Log("Slot 3 Found");
            ItemImage = GameObject.Find("S3").GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IDLoad()
    {
        if (gameObject.name == "Slot 1" && gameObject.tag == "SlotWeapon")
        {
            Debug.Log("Slot 1 ID Loaded");
            ItemID = InventoryManager.slot1_id;

        }
        if (gameObject.name == "Slot 2" && gameObject.tag == "SlotWeapon")
        {
            Debug.Log("Slot 2 ID Loaded");
            ItemID = InventoryManager.slot2_id;
        }
        if (gameObject.name == "Slot 3" && gameObject.tag == "SlotPotion")
        {
            Debug.Log("Slot 3 ID Loaded");
            ItemID = InventoryManager.slot3_id;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(ItemEnable)
        {
            Cursor.visible = false;
            ItemInfo.SetActive(true);
            InfoReload();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ItemEnable)
        {
            Cursor.visible = true;
            ItemInfo.SetActive(false);
        }

    }
    [ContextMenu("DataReload")]
    void DataReload()
    {
        var data = ItemDataManager.LoadData(ItemID);
        Sprite img = Resources.Load<Sprite>($"ItemSprites/{data.image}");
        ItemImage.sprite = img;
    }

    

    [ContextMenu("InfoReload")]
    void InfoReload()
    {

        ResetText();
       var data = ItemDataManager.LoadData(ItemID);
        Item_Name.text = data.name;
        if(data.ad != 0)
        {
            Item_Stats.text += $"<color=#ff8400>공격력</color> {data.ad}\n";
        }
        if(data.ap != 0)
        {
            Item_Stats.text += $"<color=#5d00ff>주문력</color> {data.ap}\n";
        }
        if(data.hp != 0)
        {
            Item_Stats.text += $"<color=#00b51e>체력</color> {data.hp}\n";
        }
        if(data.spd != 0)
        {
            Item_Stats.text += $"<color=#ffffff>이동 속도</color> {data.spd}\n";
        }
        if(data.atkspd != 0)
        {
            Item_Stats.text += $"<color=#ffed4f>공격 속도</color> {data.atkspd}%\n";
        }
    }
}
