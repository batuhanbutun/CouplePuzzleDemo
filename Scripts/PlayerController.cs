using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 _moveDir;

    [SerializeField] float _movementSpeed;
    [SerializeField] Rigidbody _playerRb;
    [SerializeField] Joystick _myJoystick;
    [SerializeField] private Vector3 _lookDir;

    [SerializeField] private bool _isActive;
    public bool isActive { get { return _isActive; } set { _isActive = value; } }

    private Animator _myAnim;
    [SerializeField] GameObject _wonPanel;

    private float forcePower = 2f;

    private void Start()
    {
        _myAnim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (_isActive)
        {
            _moveDir = new Vector3(_myJoystick.Horizontal, 0, _myJoystick.Vertical);
            _lookDir = new Vector3(transform.position.x + _myJoystick.Horizontal, transform.position.y, transform.position.z + _myJoystick.Vertical);
            _playerRb.velocity = _moveDir * (_movementSpeed);
            if (_moveDir.magnitude > 0)
                _myAnim.SetBool("isRunning", true);
            else
                _myAnim.SetBool("isRunning", false);
            transform.LookAt(_lookDir);
        }
     
    }


    private void OnCollisionStay(Collision collision)
    {
       if (_moveDir.magnitude > 0)
        {
            Rigidbody obstacleRb = collision.collider.attachedRigidbody;

            if(obstacleRb != null)
            {
                _myAnim.SetBool("isPushing", true);
                Vector3 forceDirection = collision.collider.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                obstacleRb.AddForceAtPosition(forceDirection * forcePower, transform.position, ForceMode.Impulse);
            }
        }
        else
            _myAnim.SetBool("isPushing", false);
        if (collision.gameObject.CompareTag("Player"))
        {
            _wonPanel.SetActive(true);
        }
    }

}
