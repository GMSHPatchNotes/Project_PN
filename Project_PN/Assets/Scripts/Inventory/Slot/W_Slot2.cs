using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using JetBrains.Annotations;

public class W_Slot2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public static Action W2_ReloadInfoData;

    public static Action W2_ReloadData;

    public static Action W2_ReloadID;

    public bool ItemEnable = false;

    public static bool MouseOverlaping = false;
    // Start is called before the first frame update
    private void Awake()
    {
        W2_ReloadInfoData = () => { InfoReload(); };

        W2_ReloadData = () => { DataReload(); };

        W2_ReloadID = () => { IDLoad(); };

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
        ItemImage = GetComponentInChildren<Image>();
        DataReload();
    }

    // Update is called once per frame


    void IDLoad()
    {
       ItemID = InventoryManager.slot2_id;
    }
    private void Update()
    {
        if(InventoryManager.slot2_id != 0)
        {
            ItemEnable = true;
        }
        else
        {
            ItemEnable = false;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ItemEnable)
        {
            Cursor.visible = false;
            MouseOverlaping = true;
            ItemInfo.SetActive(true);
            InfoReload();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ItemEnable)
        {
            Cursor.visible = true;
            MouseOverlaping = false;
            ItemInfo.SetActive(false);
        }

    }
    [ContextMenu("DataReload")]
    void DataReload()
    {
        if(InventoryManager.slot2_id == 0)
        {
            Sprite img = Resources.Load<Sprite>($"ItemSprites/None");
            ItemImage.sprite = img;
        }
        else
        {
            var data = ItemDataManager.LoadData(ItemID);
            Sprite img = Resources.Load<Sprite>($"ItemSprites/{data.image}");
            ItemImage.sprite = img;

        }
        
    }



    [ContextMenu("InfoReload")]
    void InfoReload()
    {

        ResetText();
        var data = ItemDataManager.LoadData(ItemID);
        Item_Name.text = data.name;
        if (data.ad != 0)
        {
            Item_Stats.text += $"<color=#ff8400>공격력</color> {data.ad}\n";
        }
        if (data.ap != 0)
        {
            Item_Stats.text += $"<color=#5d00ff>주문력</color> {data.ap}\n";
        }
        if (data.hp != 0)
        {
            Item_Stats.text += $"<color=#00b51e>체력</color> {data.hp}\n";
        }
        if (data.spd != 0)
        {
            Item_Stats.text += $"<color=#ffffff>이동 속도</color> {data.spd}\n";
        }
        //if (data.atkspd != 0)
        //{
        //    Item_Stats.text += $"<color=#ffed4f>공격 속도</color> {data.atkspd}%\n";
        //}
    }
}
