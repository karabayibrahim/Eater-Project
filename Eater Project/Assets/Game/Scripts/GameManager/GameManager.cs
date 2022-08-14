using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager :MonoSingleton<GameManager>
{
    public Joystick Joystick;
    public PlayerController Player;
    public CraftManager CraftManager;
    public Button CraftRyBut;
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
