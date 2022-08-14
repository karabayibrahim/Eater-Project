using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour,IPlayerCollectable
{
    public List<ResourceObject> ResourceObjects = new List<ResourceObject>();
    [SerializeField] private PotionObject craftObject;

    public void DoPlayerCollect()
    {
        var player = GameManager.Instance.Player;
        if (player.MyHandResourceObject)
        {
            ResourceObjects.Add(player.MyHandResourceObject);
            player.MyHandResourceObject.gameObject.SetActive(false);
            player.MyHandResourceObject = null;
            craftObject.CraftableControl();
        }
    }

    void Start()
    {
        GameManager.Instance.CraftRyBut.onClick.AddListener(CraftSpawnObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CraftSpawnObject()
    {
        if (craftObject.Craftable)
        {
            Instantiate(craftObject);
        }
    }


}
