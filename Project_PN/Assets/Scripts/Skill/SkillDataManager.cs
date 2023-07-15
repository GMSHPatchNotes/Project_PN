using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataManager : MonoBehaviour
{
    private static SkillDataManager instance;
    private SkillDataManager()
    {

    }

    public static SkillDataManager GetInstance()
    {
        if (SkillDataManager.instance == null)
        {
            SkillDataManager.instance = new SkillDataManager();
        }
        return SkillDataManager.instance;
    }

    public static SkillData LoadData(uint itemID)
    {
        var json = Resources.Load<TextAsset>("SkillData/SkillData").text;
        var ArrayItemDatas = JsonConvert.DeserializeObject<SkillData[]>(json);
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
