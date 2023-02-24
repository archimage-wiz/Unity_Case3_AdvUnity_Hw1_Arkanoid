using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksCreator : MonoBehaviour
{
    [SerializeField] int BricksMatrix_x, BricksMatrix_y;
    private GameObject [][] _bricks;

   
    void Start()
    {

        _bricks = new GameObject[BricksMatrix_y][];
        for (int i = 0; i < BricksMatrix_y; i++) {
            _bricks[i] = new GameObject[BricksMatrix_x];
        }

        var _brick = Resources.Load("Brick", typeof(GameObject)) as GameObject;

        for(int y_cnt = 0; y_cnt < _bricks.Length; y_cnt++)
        {
            for(int x_cnt = 0; x_cnt < _bricks[y_cnt].Length; x_cnt++)
            {
                _bricks[y_cnt][x_cnt] = Instantiate(_brick, new Vector3(0, (BricksMatrix_y - y_cnt) * 0.5f, x_cnt - (BricksMatrix_x/2)), Quaternion.identity, this.gameObject.transform);
                _bricks[y_cnt][x_cnt].transform.Rotate(0, yAngle:90, 0);
            }            
        }        
        
    }


}
