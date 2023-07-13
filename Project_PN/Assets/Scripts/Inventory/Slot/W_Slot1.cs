using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using JetBrains.Annotations;

public class W_Slot1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("������ ���� ǥ�� UI")]
    [SerializeField] GameObject ItemInfo;

    [Header("������ ID")]
    [SerializeField] uint ItemID;

    [Header("���� �̹���")]
    Image ItemImage;

    [Header("Info")]
    [SerializeField] Text Item_Name;
    [SerializeField] Text Item_Stats;
    [SerializeField] Text Item_Desc;

    public static Action W1_ReloadInfoData;

    public static Action W1_ReloadData;

    public static Action W1_ReloadID;

    public bool ItemEnable = false;

    public static bool MouseOverlaping = false;
    // Start is called before the first frame update
    private void Awake()
    {
        W1_ReloadInfoData = () => { InfoReload(); };

        W1_ReloadData = () => { DataReload(); };

        W1_ReloadID = () => { IDLoad(); };

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
    }

    // Update is called once per frame


    void IDLoad()
    {
       ItemID = InventoryManager.slot1_id;
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
        if (data.ad != 0)
        {
            Item_Stats.text += $"<color=#ff8400>���ݷ�</color> {data.ad}\n";
        }
        if (data.ap != 0)
        {
            Item_Stats.text += $"<color=#5d00ff>�ֹ���</color> {data.ap}\n";
        }
        if (data.hp != 0)
        {
            Item_Stats.text += $"<color=#00b51e>ü��</color> {data.hp}\n";
        }
        if (data.spd != 0)
        {
            Item_Stats.text += $"<color=#ffffff>�̵� �ӵ�</color> {data.spd}\n";
        }
        if (data.atkspd != 0)
        {
            Item_Stats.text += $"<color=#ffed4f>���� �ӵ�</color> {data.atkspd}%\n";
        }
    }
}
