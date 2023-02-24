using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{

    [SerializeField] protected float _upper_bone = 9;
    [SerializeField] protected float _lower_bone = 1;
    [SerializeField] protected float _left_bone = -3;
    [SerializeField] protected float _right_bone = 3;
    [SerializeField] protected float _player_move_acceleration = 0.05f;
    protected PlayerInputMap _input;
    protected Vector2 xy;
    protected Vector3 _player_move = new Vector3(0, 0, 0);
    protected int _player_score = 0;

    void Awake() {
        _input = new PlayerInputMap();
    }
    void Start()
    {
                        
    }
    void OnEnable() {
        _input.ActionMap.Enable();
        _input.ActionMap.Player2Move.performed += OnMove;
    }
    void OnMove(CallbackContext context){ }
    public Vector2 GetVector2Velocity() {
        return new Vector2(_player_move.z, _player_move.y);
    }
    public void AddScore(int x){
        _player_score += x;
        //Debug.Log(this + " " + _player_score);
    }
    protected void PlayerMove(Vector2 xy) {

        //xy = _input.ActionMap.Player2Move.ReadValue<Vector2>();                
        
        if (xy.x > 0 && _player_move.z < 1) { _player_move += new Vector3(0, 0, _player_move_acceleration) * Time.deltaTime; }
        if (xy.x < 0 && _player_move.z > -1) { _player_move -= new Vector3(0, 0, _player_move_acceleration) * Time.deltaTime; }
        if (xy.x == 0 && _player_move.z > 0) { _player_move -= new Vector3(0, 0, _player_move.z / 1.1f) * Time.deltaTime; }
        if (xy.x == 0 && _player_move.z < 0) { _player_move -= new Vector3(0, 0, _player_move.z / 1.1f) * Time.deltaTime; }
       
        if (xy.y > 0 && _player_move.y < 1) { _player_move += new Vector3(0, _player_move_acceleration, 0) * Time.deltaTime; }
        if (xy.y < 0 && _player_move.y > -1) { _player_move -= new Vector3(0, _player_move_acceleration, 0) * Time.deltaTime; }
        if (xy.y == 0 && _player_move.y > 0) { _player_move -= new Vector3(0, _player_move.y / 1.1f, 0) * Time.deltaTime; }
        if (xy.y == 0 && _player_move.y < 0) { _player_move -= new Vector3(0, _player_move.y / 1.1f, 0) * Time.deltaTime; }

        transform.position += _player_move;

        if (transform.position.z > _right_bone) { 
            transform.position = new Vector3(transform.position.x, transform.position.y, _right_bone);
            _player_move = new Vector3(0, _player_move.y, 0);
        }
        if (transform.position.z < _left_bone) { 
            transform.position = new Vector3(transform.position.x, transform.position.y, _left_bone); 
            _player_move = new Vector3(0, _player_move.y, 0);
        }
        if (transform.position.y > _upper_bone) {
            transform.position = new Vector3(transform.position.x, _upper_bone, transform.position.z);
            _player_move = new Vector3(0, 0, _player_move.z);
        }
        if (transform.position.y < _lower_bone) {
            transform.position = new Vector3(transform.position.x, _lower_bone, transform.position.z);
            _player_move = new Vector3(0, 0, _player_move.z);
        }
    }
}
