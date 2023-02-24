using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player1Controller : PlayerController
{
    [SerializeField] private Canvas _text;

        void Update(){
        xy = _input.ActionMap.Player1Move.ReadValue<Vector2>();
        PlayerMove(xy);
        FindObjectOfType<Player1_text>().GetComponent<Text>().text = _player_score.ToString();
    }

}
