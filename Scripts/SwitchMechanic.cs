using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwitchMechanic : MonoBehaviour
{
    [SerializeField] GameObject _door;
    private float _doorOpenRange = 1.67f;
    private float _doorOpenTime = 1f;
    private float _firstPos;
    Color _firstColor;

    private bool isObstacleUp = false;

    private void Start()
    {
        _firstPos = _door.transform.position.y;
        _firstColor = gameObject.GetComponent<Renderer>().material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        _door.transform.DOMoveY(_doorOpenRange, _doorOpenTime);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            isObstacleUp = true;
        }
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            isObstacleUp = false;
        }

        if (!isObstacleUp)
        {
            _door.transform.DOMoveY(_firstPos, 1f);
            gameObject.GetComponent<Renderer>().material.color = _firstColor;
        }
    }
}
