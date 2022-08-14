using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObject : MonoBehaviour,IPlayerCollectable
{
    public ResourceType MyType;

    public void DoPlayerCollect()
    {
        GameManager.Instance.Player.MyHandResourceObject = this;
        gameObject.transform.SetParent(GameManager.Instance.Player.transform);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
