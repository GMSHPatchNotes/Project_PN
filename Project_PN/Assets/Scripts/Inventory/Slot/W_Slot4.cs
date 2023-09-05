using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using JetBrains.Annotations;

public class W_Slot4 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("아이템 정보 표시 UI")]
    [SerializeField] GameObject ItemInfo;

    [Header("아이템 ID")]
    [SerializeField] uint ItemID;

    [Header("슬롯 이미지")]
    Image SkillImage;

    [Header("Info")]
    [SerializeField] Text Skill_Name;
    [SerializeField] Text Skill_Stats;
    [SerializeField] Text Skill_Desc;

    public static Action W4_ReloadInfoData;

    public static Action W4_ReloadData;

    public static Action W4_ReloadID;

    public bool ItemEnable = false;

    public static bool MouseOverlaping = false;
    // Start is called before the first frame update
    private void Awake()
    {
        W4_ReloadInfoData = () => { InfoReload(); };

        W4_ReloadData = () => { DataReload(); };

        W4_ReloadID = () => { IDLoad(); };

    }
    void ResetText()
    {
        Skill_Name.text = "";
        Skill_Stats.text = "";
        Skill_Desc.text = "";
    }


    void Start()
    {
        ResetText();
        IDLoad();
        SkillImage = GetComponent<Image>();
        DataReload();
    }

    // Update is called once per frame


    void IDLoad()
    {
       ItemID = InventoryManager.slot1_id;
    }

    private void Update()
    {
        if(InventoryManager.slot1_id == 301)
        {
            ItemEnable = false;
        }
        else
        {
            ItemEnable = true;
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
        Sprite img;
        if (InventoryManager.slot1_id == 301)
        {
            img = Resources.Load<Sprite>($"ItemSprites/None");
            SkillImage.sprite = img;
        }
        else
        {
            var data = SkillDataManager.LoadData(ItemID);
            img = Resources.Load<Sprite>($"SkillSprites/{data.name}");
            SkillImage.sprite = img;
        }
        
    }



    [ContextMenu("InfoReload")]
    void InfoReload()
    {

        ResetText();
        var data = SkillDataManager.LoadData(ItemID);
        Skill_Name.text = data.displayName;
        Skill_Desc.text = data.desc;
    }
}
