using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableObjects : MonoBehaviour,IPlayerCollectable
{
    [SerializeField] private EatableObjectType myeatableObjectType;
    public void DoPlayerCollect()
    {
        switch (myeatableObjectType)
        {
            case EatableObjectType.COLLECTED:
                Destroy(gameObject);
                break;
            case EatableObjectType.EATER:
                GameManager.Instance.Player.EatFeature();
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
