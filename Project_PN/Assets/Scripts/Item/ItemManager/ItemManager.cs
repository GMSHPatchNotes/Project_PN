using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Data
{
    id,
    name,
    hp,
    ad,
    ap,
    spd,
    duration,
    atkspd,
    desc,
    skillname,
    type
}
public class ItemManager : MonoBehaviour
{
    [Header("아이템 ID")]
    public uint ID;

    [Header("종류")]
    public Data Type;
    private void Awake()
    {
        ItemDataManager.GetInstance();
    }
    // Start is called before the first frame update
    void Start()
    {
        switch((int)Type)
        {
            case 0:
                Debug.Log(ItemDataManager.LoadData(ID).id);
                break;
            case 1:
                Debug.Log(ItemDataManager.LoadData(ID).name);
                break;
            case 2:
                Debug.Log(ItemDataManager.LoadData(ID).hp);
                break;
            case 3:
                Debug.Log(ItemDataManager.LoadData(ID).ad);
                break;
            case 4:
                Debug.Log(ItemDataManager.LoadData(ID).ap);
                break;
            case 5:
                Debug.Log(ItemDataManager.LoadData(ID).spd);
                break;
            case 6:
                Debug.Log(ItemDataManager.LoadData(ID).duration);
                break;
            case 7:
                Debug.Log(ItemDataManager.LoadData(ID).atkspd);
                break;
            case 8:
                Debug.Log(ItemDataManager.LoadData(ID).desc);
                break;
            case 9:
                Debug.Log(ItemDataManager.LoadData(ID).skillname);
                break;
            case 10:
                Debug.Log(ItemDataManager.LoadData(ID).type);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
