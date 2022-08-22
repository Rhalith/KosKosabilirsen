using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MiniGames.KosKosabilirsen.Scripts.Player
{
    public class PlayerSpecs : MonoBehaviour
    {
        [SerializeField] private int _playerHealth;
<<<<<<< HEAD
        [Tooltip("Move speed of the character in m/s")]
        [SerializeField] private float _playerMoveSpeed;

        [Tooltip("Sprint speed of the character in m/s")]
        [SerializeField] private float _playerSlowSpeed;

        [Tooltip("How fast the character turns to face movement direction")]
        [Range(0.0f, 0.3f)]
        [SerializeField] private float _playerRotationSpeed;

        [Tooltip("Acceleration and deceleration")]
        [SerializeField] private float _speedChangeRate = 10.0f;
        private bool _isSlow;
=======
        [SerializeField] private float _playerMoveSpeed;
        [SerializeField] private float _playerRotationSpeed;
        private float _localMoveSpeed;
>>>>>>> b62845da (added player scripts)

        public int PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
        public float PlayerMoveSpeed { get => _playerMoveSpeed; set => _playerMoveSpeed = value; }
        public float PlayerRotationSpeed { get => _playerRotationSpeed; set => _playerRotationSpeed = value; }
<<<<<<< HEAD
        public float PlayerSlowSpeed { get => _playerSlowSpeed; set => _playerSlowSpeed = value; }
        public bool IsSlow { get => _isSlow; set => _isSlow = value; }
        public float SpeedChangeRate { get => _speedChangeRate; set => _speedChangeRate = value; }
=======

        private void Awake()
        {
            _localMoveSpeed = _playerMoveSpeed;
        }
        /// <summary>
        /// PlayerSpeed returns normal.
        /// </summary>
        public void ResetPlayerSpeed()
        {
            _playerMoveSpeed = _localMoveSpeed;
        }
        /// <summary>
        /// PlayerSpeed multiplies with ratio.
        /// </summary>
        /// <param name="ratio"></param>
        public void ChangePlayerSpeed(float ratio)
        {
            _playerMoveSpeed *= ratio;
        }
>>>>>>> b62845da (added player scripts)
    }
}