using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDataManager : MonoBehaviour
{
    private static ItemDataManager instance;
    private ItemDataManager()
    {

    }

    public static ItemDataManager GetInstance()
    {
        if(ItemDataManager.instance == null)
        {
            ItemDataManager.instance = new ItemDataManager();
        }
        return ItemDataManager.instance;
    }

    public static ItemData LoadData(uint itemID)
    {
        var json = Resources.Load<TextAsset>("ItemData/ItemData").text;
        var ArrayItemDatas = JsonConvert.DeserializeObject<ItemData[]>(json);
        for (int i = 0; i < ArrayItemDatas.Length; i++)
        {
            if (ArrayItemDatas[i].id == itemID)
            {
                return ArrayItemDatas[i];
            }
        }
        return null;
    }
}
