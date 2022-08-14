using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerState myState;
    private Joystick myJoystick;
    [SerializeField] private float speed;
    public bool EatStatus = false;
    public ResourceObject MyHandResourceObject;
    
    public PlayerState State
    {
        get
        {
            return myState;
        }
        set
        {
            if (State == value)
            {
                return;
            }
            myState = value;
            OnStateChanges();
        }
    }

    private void OnStateChanges()
    {
        switch (State)
        {
            case PlayerState.IDLE:
                
                break;
            case PlayerState.RUN:
                
                break;
            default:
                break;
        }
    }
    void Start()
    {
        myJoystick = GameManager.Instance.Joystick;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveControl();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IPlayerCollectable>()!=null)
        {
            other.GetComponent<IPlayerCollectable>().DoPlayerCollect();
        }
    }

    private void PlayerMoveControl()
    {
        if (myJoystick.Direction.x != 0 || myJoystick.Direction.y != 0)
        {
            State = PlayerState.RUN;
        }
        else
        {
            State = PlayerState.IDLE;
        }
        Vector3 myDirection = new Vector3(myJoystick.Direction.x, 0, myJoystick.Direction.y).normalized;
        transform.Translate(myDirection * Time.deltaTime * speed, Space.World);
        Vector3 lookAtPoz = transform.position + myDirection;
        transform.LookAt(lookAtPoz);
    }

    private IEnumerator EatStatusControl()
    {
        EatStatus = true;
        yield return new WaitForSeconds(5f);
        EatStatus = false;
    }

    public void EatFeature()
    {
        StartCoroutine(EatStatusControl());
    }
}
