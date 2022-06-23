using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] PlayerController _player1;
    [SerializeField] PlayerController _player2;

    void Start()
    {
        _player1.isActive = true;
        _player2.isActive = false;
    }

    public void ChangePlayer()
    {
        if (_player1.isActive)
        {
            _player1.isActive = false;
            _player2.isActive = true;
        }
        else
        {
            _player1.isActive = true;
            _player2.isActive = false;
        }
    }
}
