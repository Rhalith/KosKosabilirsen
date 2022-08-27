<<<<<<< HEAD
=======
using Assets.MiniGames.KosKosabilirsen.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
>>>>>>> 9ab500f1 (new character controller and combat cam)
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.MiniGames.KosKosabilirsen.Scripts.ThirdPerson
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
<<<<<<< HEAD
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _sprintSpeed;
        [SerializeField] private float _groundDrag;
        [SerializeField] private float _airMultiplier;
        private float _moveSpeed;
        private Vector3 moveDirection;
=======
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _groundDrag;
        [SerializeField] private float _airMultiplier;
>>>>>>> 9ab500f1 (new character controller and combat cam)

        [SerializeField] private Transform _orientation;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private PlayerInputReceiver _playerInputReceiver;
<<<<<<< HEAD
        [SerializeField] private Grappling _grappling;
=======
>>>>>>> 9ab500f1 (new character controller and combat cam)

        [Header("Ground Check")]
        public float playerHeight;
        public LayerMask whatIsGround;
        public bool grounded;

<<<<<<< HEAD
        [Header("State")]
        public MovementState state;
        private bool _freeze;
        private bool _sprint;
        private bool _isGrappleActive;
        private bool _enableMovement;
        private Vector3 _velocityToSet;

        public bool Freeze { get => _freeze; set => _freeze = value; }
        public bool Sprint { get => _sprint; set => _sprint = value; }

        public enum MovementState
        {
            freeze,
            walking,
            sprinting
        }


=======
>>>>>>> 9ab500f1 (new character controller and combat cam)
        private void FixedUpdate()
        {
            MovePlayer();
        }
<<<<<<< HEAD

        private void OnCollisionEnter(Collision collision)
        {
            if (_enableMovement)
            {
                _enableMovement = false; ResetRestrictions(); _grappling.StopGrapple();
            }
        }

        public void ResetRestrictions()
        {
            _isGrappleActive = false;
        }
        private void StateHandler()
        {
            //Mode - Freeze
            if (_freeze)
            {
                state = MovementState.freeze;
                _moveSpeed = 0;
                _rb.velocity = Vector3.zero;
            }
            else if (_sprint)
            {
                state = MovementState.sprinting;
            }
            else
            {
                state = MovementState.walking;
            }
        }
=======
>>>>>>> 9ab500f1 (new character controller and combat cam)
        private void Update()
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            SpeedControl();
<<<<<<< HEAD
            StateHandler();

            if (grounded && !_isGrappleActive)
=======

            if (grounded)
>>>>>>> 9ab500f1 (new character controller and combat cam)
            {
                _rb.drag = _groundDrag;
            }
            else
            {
                _rb.drag = 0;
            }
        }

<<<<<<< HEAD
        public void JumpToPosition(Vector3 target, float trajectoryHeight)
        {
            _isGrappleActive = true;
            _velocityToSet = CalculateJumpVelocity(transform.position, target, trajectoryHeight);
            Invoke(nameof(SetVelocity), 0.1f);

            //in case of something went wrong
            Invoke(nameof(ResetRestrictions), 3f);
        }

        private void SetVelocity()
        {
            _enableMovement = true;
            _rb.velocity = _velocityToSet;
        }
        private void MovePlayer()
        {
            if (_isGrappleActive)
            {
                return;
            }
            moveDirection = _orientation.forward * _playerInputReceiver.move.y + _orientation.right * _playerInputReceiver.move.x;
            _moveSpeed = _sprint ? _sprintSpeed : _walkSpeed;
=======
        Vector3 moveDirection;
        private void MovePlayer()
        {
            moveDirection = _orientation.forward * _playerInputReceiver.move.y + _orientation.right * _playerInputReceiver.move.x;
>>>>>>> 9ab500f1 (new character controller and combat cam)

            if (grounded)
            {
                _rb.AddForce(moveDirection.normalized * _moveSpeed * 20f, ForceMode.Force);
            }
            else
            {
                _rb.AddForce(moveDirection.normalized * _moveSpeed * 20f* _airMultiplier, ForceMode.Force);
            }
        }

        private void SpeedControl()
        {
<<<<<<< HEAD
            if (_isGrappleActive)
            {
                return;
            }
=======
>>>>>>> 9ab500f1 (new character controller and combat cam)
            Vector3 currentVelocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if(currentVelocity.magnitude > _moveSpeed)
            {
                Vector3 limitedVelocity = currentVelocity.normalized * _moveSpeed;

                _rb.velocity = new Vector3(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
            }
        }

<<<<<<< HEAD
        private Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
        {
            float gravity = Physics.gravity.y;
            float displacementY = endPoint.y - startPoint.y;
            Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

            Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
            Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity)
                + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

            return velocityXZ + velocityY;
        }
=======

>>>>>>> 9ab500f1 (new character controller and combat cam)
    }

}