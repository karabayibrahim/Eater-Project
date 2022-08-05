using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :MonoSingleton<GameManager>
{
    public Joystick Joystick;
    public PlayerController Player;
    void Start()
    {
        FinderObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FinderObjects()
    {
        Player = FindObjectOfType<PlayerController>();
        Joystick = FindObjectOfType<Joystick>();
    }
}
