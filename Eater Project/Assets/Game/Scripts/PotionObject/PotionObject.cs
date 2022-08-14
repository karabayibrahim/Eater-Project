using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionObject : MonoBehaviour
{
    [SerializeField] private PotionType potionType;
    public int RedGem;
    public int BlueGem;
    public bool Craftable = false;
    void Start()
    {
        TypeNeedResources();
        Craftable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TypeNeedResources()
    {
        switch (potionType)
        {
            case PotionType.TYPE1:
                RedGem = 2;
                BlueGem = 0;
                break;
            default:
                break;
        }
    }

    public void CraftableControl()
    {
        foreach (var item in GameManager.Instance.CraftManager.ResourceObjects)
        {
            switch (item.MyType)
            {
                case ResourceType.RED:
                    RedGem--;
                    
                    break;
                case ResourceType.BLUE:
                    BlueGem--;
                    
                    break;
                default:
                    break;
            }
            ClearItemObject(item);
        }
        if (RedGem==0&&BlueGem==0)
        {
            Craftable = true;
        }
    }

    private void ClearItemObject(ResourceObject res)
    {
        GameManager.Instance.CraftManager.ResourceObjects.Remove(res);
        Destroy(res.gameObject);
    }
}
