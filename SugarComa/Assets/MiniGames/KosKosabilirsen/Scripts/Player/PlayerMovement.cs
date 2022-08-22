using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
<<<<<<< HEAD
=======
using UnityEngine.InputSystem;
//using Assets.MiniGames.KosKosabilirsen.Scripts.Input;
>>>>>>> ff1befd9 (player movement & thirdperson asset added)
=======
using UnityEngine.InputSystem;
using Assets.MiniGames.KosKosabilirsen.Scripts.Input;
>>>>>>> cc92a396 (player inputs and animations added)

namespace Assets.MiniGames.KosKosabilirsen.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        
=======
        //private Inputs _playerInput;
=======
        private Inputs _playerInput;
>>>>>>> e93361ff (input system adjustments has been made)
        private Vector3 _movementDirection;
        private Vector3 _rotationDirection;
        private bool _isJumping;
        private bool _isGamepadActive;
        private bool _isMouseActive;

        [SerializeField] private PlayerSpecs _playerSpec;
        [SerializeField] private PlayerAnimation _playerAnimation;

        private void Awake()
        {
            //_playerInput = new();

<<<<<<< HEAD
            //EnableActions();
            //AddJumpActions();
            //AddMoveActions();
            //AddGamepadRotationActions();
=======
            EnableActions();
            AddJumpActions();
            AddMoveActions();
            AddGamepadRotationActions();
>>>>>>> e93361ff (input system adjustments has been made)
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (_playerSpec.PlayerMoveSpeed > 0)
            {
                //RotatePlayer();
                if (_isGamepadActive)
                {
                    RotateWithGamepad(_rotationDirection);
                }
                TranslatePlayer();
            }
            else
            {
                _playerAnimation.StopRunning();
            }
<<<<<<< HEAD
        }
        //private void RotatePlayer()
        //{
        //    if (_isMouseActive)
        //    {
        //        RotateWithMouse(_mouseDir);
        //    }
        //    else if (_isGamepadActive)
        //    {
        //        RotateWithGamepad(_rotationDirection);
        //    }
        //    else if (_movementDir.x != 0 || _movementDir.z != 0)
        //    {
        //        RotateWithMovement(_movementDir);
        //    }
        //}

        private void TranslatePlayer()
        {
            if (_movementDirection.x != 0 || _movementDirection.z != 0)
            {
                transform.Translate(_playerSpec.PlayerMoveSpeed * Time.deltaTime * _movementDirection.normalized, Space.World);
                _playerAnimation.StartRunning();
            }
            else
            {
                _playerAnimation.StopRunning();
            }
        }

        //TODO
        //private void RotateWithMouse(Vector3 direction)
        //{
        //    _ray = _cam.ScreenPointToRay(direction);
        //    if (Physics.Raycast(_ray, out _hit))
        //    {
        //        if (!_hit.collider.CompareTag("Player"))
        //        {
        //            Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(_hit.point.x - transform.position.x, 0, _hit.point.z - transform.position.z), Vector3.up);
        //            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _playerSpec.PlayerRotationSpeed * Time.deltaTime);
        //        }
        //    }
        //}

        private void RotateWithGamepad(Vector3 direction)
        {
            if (direction.x != 0 || direction.z != 0)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _playerSpec.PlayerRotationSpeed * Time.deltaTime);
            }
        }

        //private void EnableActions()
        //{
        //    _playerInput.Movement.Enable();
        //    _playerInput.Hook.Enable();
        //    _playerInput.Rotation.Enable();
        //}

        //private void AddMoveActions()
        //{
        //    _playerInput.Movement.Move.started += MoveAction;
        //    _playerInput.Movement.Move.performed += MoveAction;
        //    _playerInput.Movement.Move.canceled += MoveAction;
        //}

        //private void MoveAction(InputAction.CallbackContext obj)
        //{
        //    print("moveperformed");
        //    Vector2 direction = obj.ReadValue<Vector2>();
        //    _movementDirection.x = direction.x;
        //    _movementDirection.z = direction.y;
        //}
        //private void AddJumpActions()
        //{
        //    _playerInput.Movement.Jump.started += JumpAction;
        //    _playerInput.Movement.Jump.performed += JumpAction;
        //    _playerInput.Movement.Jump.canceled += JumpAction;
        //}
        //private void JumpAction(InputAction.CallbackContext obj)
        //{
        //    print("jumpperformed");
        //    _isJumping = obj.performed;
        //}

        //private void AddGamepadRotationActions()
        //{
        //    _playerInput.Rotation.RotateWithGamepad.started += RotateAction;
        //    _playerInput.Rotation.RotateWithGamepad.performed += RotateAction;
        //    _playerInput.Rotation.RotateWithGamepad.canceled += RotateAction;
        //}

=======
        }
        //private void RotatePlayer()
        //{
        //    if (_isMouseActive)
        //    {
        //        RotateWithMouse(_mouseDir);
        //    }
        //    else if (_isGamepadActive)
        //    {
        //        RotateWithGamepad(_rotationDirection);
        //    }
        //    else if (_movementDir.x != 0 || _movementDir.z != 0)
        //    {
        //        RotateWithMovement(_movementDir);
        //    }
        //}

        private void TranslatePlayer()
        {
            if (_movementDirection.x != 0 || _movementDirection.z != 0)
            {
                transform.Translate(_playerSpec.PlayerMoveSpeed * Time.deltaTime * _movementDirection.normalized, Space.World);
                _playerAnimation.StartRunning();
            }
            else
            {
                _playerAnimation.StopRunning();
            }
        }

        //TODO
        //private void RotateWithMouse(Vector3 direction)
        //{
        //    _ray = _cam.ScreenPointToRay(direction);
        //    if (Physics.Raycast(_ray, out _hit))
        //    {
        //        if (!_hit.collider.CompareTag("Player"))
        //        {
        //            Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(_hit.point.x - transform.position.x, 0, _hit.point.z - transform.position.z), Vector3.up);
        //            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _playerSpec.PlayerRotationSpeed * Time.deltaTime);
        //        }
        //    }
        //}

        private void RotateWithGamepad(Vector3 direction)
        {
            if (direction.x != 0 || direction.z != 0)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _playerSpec.PlayerRotationSpeed * Time.deltaTime);
            }
        }

        private void EnableActions()
        {
            _playerInput.Movement.Enable();
            _playerInput.Hook.Enable();
            _playerInput.Rotation.Enable();
        }

        private void AddMoveActions()
        {
            _playerInput.Movement.Move.started += MoveAction;
            _playerInput.Movement.Move.performed += MoveAction;
            _playerInput.Movement.Move.canceled += MoveAction;
        }

        private void MoveAction(InputAction.CallbackContext obj)
        {
            print("moveperformed");
=======
        private PlayerInputs _playerInput;

        private Vector3 _movementDirection;
        private bool _isJumping;

        private void Awake()
        {
            _playerInput = new();


            _playerInput.Movement.Move.performed += Move_performed;
            _playerInput.Movement.Jump.started += Jump_started;
        }

        private void Jump_started(InputAction.CallbackContext obj)
        {
            _isJumping = obj.performed;
        }

        private void Move_performed(InputAction.CallbackContext obj)
        {
>>>>>>> cc92a396 (player inputs and animations added)
            Vector2 direction = obj.ReadValue<Vector2>();
            _movementDirection.x = direction.x;
            _movementDirection.z = direction.y;
        }
<<<<<<< HEAD
        private void AddJumpActions()
        {
            _playerInput.Movement.Jump.started += JumpAction;
            _playerInput.Movement.Jump.performed += JumpAction;
            _playerInput.Movement.Jump.canceled += JumpAction;
        }
        private void JumpAction(InputAction.CallbackContext obj)
        {
            print("jumpperformed");
            _isJumping = obj.performed;
        }

        private void AddGamepadRotationActions()
        {
            _playerInput.Rotation.RotateWithGamepad.started += RotateAction;
            _playerInput.Rotation.RotateWithGamepad.performed += RotateAction;
            _playerInput.Rotation.RotateWithGamepad.canceled += RotateAction;
        }

>>>>>>> e93361ff (input system adjustments has been made)
        private void RotateAction(InputAction.CallbackContext obj)
        {
            var input = obj.ReadValue<Vector2>();
            _rotationDirection.x = input.x;
            _rotationDirection.z = input.y;
            _rotationDirection = _rotationDirection.normalized;
            _isGamepadActive = obj.performed;
        }
<<<<<<< HEAD
>>>>>>> ff1befd9 (player movement & thirdperson asset added)
=======
>>>>>>> e93361ff (input system adjustments has been made)
=======
>>>>>>> cc92a396 (player inputs and animations added)
    }
}