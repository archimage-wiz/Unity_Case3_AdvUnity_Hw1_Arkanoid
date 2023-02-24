using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class Player2Controller : PlayerController
{
    [SerializeField] private Canvas _ui;
    
    void Start()
    {
                        
    }

    void Update(){
        xy = _input.ActionMap.Player2Move.ReadValue<Vector2>();
        PlayerMove(xy);
        FindObjectOfType<Player2_Text>().GetComponent<Text>().text = _player_score.ToString();
    }

}
