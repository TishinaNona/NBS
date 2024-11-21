using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float _time = 6f;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private bool _isColdown = true;
    [SerializeField] private Transform _targetSpawn;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            if (_isColdown == true && _time >= 6f)
            {
                Instantiate(_enemy, _targetSpawn.transform);
                _isColdown = false;
                _time = 0;
            }
        }
    }

    private void Update()
    {
        if (_time != 6)
        {
            _time += Time.deltaTime;
            _isColdown = true;
        }
    }
}
