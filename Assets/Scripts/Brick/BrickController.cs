using System.Collections;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private Material [] _materials;
    private GameObject _ball;
    [SerializeField] float _brick_rotation_speed = 1.0f;
    private int _self_power;
    private Coroutine _my_engine;
    private bool _my_engine_active = false;
    private Quaternion _base_rotation;

    void SetSelfPowerColor(){
        if (_self_power >= 4){
            this.GetComponentInChildren<MeshRenderer>().material = _materials[3];
            this.GetComponentInChildren<Light>().color = Color.cyan;
        }
        if (_self_power == 3){
            this.GetComponentInChildren<MeshRenderer>().material = _materials[2];
            this.GetComponentInChildren<Light>().color = Color.red;
        }
        if (_self_power == 2){
            this.GetComponentInChildren<MeshRenderer>().material = _materials[1];
            this.GetComponentInChildren<Light>().color = Color.yellow;
        }
        if (_self_power <= 1){
            this.GetComponentInChildren<MeshRenderer>().material = _materials[0];
            this.GetComponentInChildren<Light>().color = Color.green;
        }
    }

    void Start()
    {
        _self_power = 4;
        SetSelfPowerColor();
        _ball = FindObjectOfType<BallController>().gameObject;
        //Debug.Log(_ball);
        _base_rotation = transform.localRotation;
        _my_engine_active = true;
        _my_engine = StartCoroutine(BricksRotator());
    }

    private IEnumerator BricksRotator(){
        while (true) {
            transform.Rotate(new Vector3(_brick_rotation_speed, 0, 0));
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public int GetSelfPower() {
        return _self_power;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == FindObjectOfType<BallController>().gameObject){
            //Debug.Log("Ball collision");
            if (_self_power <= 1){
                if(_my_engine_active) { StopCoroutine(_my_engine); }
                Destroy(this.gameObject);
            } else {
                _self_power -= 1;            
                SetSelfPowerColor();
            }
        }
    }
    void Update(){
        if (Vector3.Distance(_ball.transform.position, transform.position) < 5.0f){
            //Debug.Log("ball in");
            StopCoroutine(_my_engine);
            _my_engine_active = false;
            transform.localRotation = _base_rotation;
        } else {
            if(_my_engine_active == false){
                _my_engine_active = true;
                _my_engine = StartCoroutine(BricksRotator());
            }
        }
    }

}
