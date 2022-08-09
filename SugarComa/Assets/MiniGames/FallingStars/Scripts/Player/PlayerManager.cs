using Assets.MiniGames.FallingStars.Scripts.Meteors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MiniGames.FallingStars.Scripts.Player
{
    public class PlayerManager: MonoBehaviour
    {
        private ClassicMeteor _classicMeteor;
        private ExplosionMeteor _explosionMeteor;
        private StickyMeteor _stickyMeteor;
        private PoisonMeteor _poisonMeteor;

        [SerializeField] private PlayerMovement _playerMovement;

        private void Awake()
        {
            _classicMeteor = new(this);
            _explosionMeteor = new(this);
            _stickyMeteor = new(this);
            _poisonMeteor = new(this);
        }

        public void DamagePlayer(float damage)
        {
            _playerMovement.PlayerSpec.Health -= damage;
            if (_playerMovement.PlayerSpec.Health <= 0) KillPlayer();
        }
        public void KillPlayer()
        {
            _playerMovement.PlayerSpec.Health = 0;
            _playerMovement.PlayerSpec.IsDead = true;
        }

        public void StartNumerator(MeteorType meteorType, float damage = 0, int duration = 0, float ratio = 0)
        {
            switch (meteorType)
            {
                case MeteorType.classic:
                    _classicMeteor._coroutine = StartCoroutine(_classicMeteor.DamageToPlayer(damage));
                    break;
                case MeteorType.explosion:
                    _explosionMeteor._coroutine = StartCoroutine(_explosionMeteor.DamageToPlayer(damage));
                    break;
                case MeteorType.poison:
                    _poisonMeteor.StopIteration();
                    _poisonMeteor._coroutine = StartCoroutine(_poisonMeteor.DamageToPlayer(damage));
                    break;
                case MeteorType.sticky:
                    _stickyMeteor._coroutine = StartCoroutine(_stickyMeteor.StopPlayer(duration, ratio));
                    break;
            }
        }
        public void StopNumerator(MeteorType meteorType, float damage = 0, int duration = 0)
        {
            switch (meteorType)
            {
                case MeteorType.classic:
                    _classicMeteor.StopIteration();
                    break;
                case MeteorType.explosion:
                    _explosionMeteor.StopIteration();
                    break;
                case MeteorType.poison:
                    _poisonMeteor.StopIteration();
                    _poisonMeteor._coroutine = StartCoroutine(_poisonMeteor.StartPoisonEffect(duration, damage));
                    break;
                case MeteorType.sticky:
                    _stickyMeteor.StopIteration();
                    _stickyMeteor.ResetPlayerSpeed();
                    break;

            }
        }
        #region ClassicMeteor

        private class ClassicMeteor
        {
            public Coroutine _coroutine;
            private readonly PlayerManager _playerManager;

            public ClassicMeteor(PlayerManager playerManager)
            {
                _playerManager = playerManager;
            }

            public IEnumerator DamageToPlayer(float damage = 0)
            {
                while (_playerManager._playerMovement.PlayerSpec.Health > 0)
                {
                    _playerManager.DamagePlayer(damage);
                    yield return new WaitForSeconds(1f);
                }
            }
            public void StopIteration()
            {
                _playerManager.StopCoroutine(_coroutine);
            }
        }
        #endregion
        #region ExplosionMeteor
        private class ExplosionMeteor
        {
            public Coroutine _coroutine;
            private readonly PlayerManager _playerManager;

            public ExplosionMeteor(PlayerManager playerManager)
            {
                _playerManager = playerManager;
            }

            public IEnumerator DamageToPlayer(float damage = 0)
            {
                while (true)
                {
                    _playerManager.DamagePlayer(damage);
                    yield return new WaitForSeconds(1f);
                }
            }
            public void StopIteration()
            {
                _playerManager.StopCoroutine(_coroutine);
            }
        }
        #endregion
        #region StickyMeteor
        private class StickyMeteor
        {
            public Coroutine _coroutine;
            private readonly PlayerManager _playerManager;

            public StickyMeteor(PlayerManager playerManager)
            {
                _playerManager = playerManager;
            }
            public IEnumerator StopPlayer(int duration = 0, float ratio = 0)
            {
                StopPlayerMovement();
                yield return new WaitForSeconds(duration);
                SlowDownPlayer(ratio);
            }
            public void SlowDownPlayer(float ratio)
            {
                ResetPlayerSpeed();
                _playerManager._playerMovement.PlayerSpec.MoveSpeed /= ratio;
            }
            public void StopPlayerMovement()
            {
                _playerManager._playerMovement.PlayerSpec.MoveSpeed = 0;
                _playerManager._playerMovement.PlayerSpec.RotationSpeed = 0;
            }
            public void ResetPlayerSpeed()
            {
                _playerManager._playerMovement.PlayerSpec.MoveSpeed = _playerManager._playerMovement.PlayerSpec.LocalMoveSpeed;
                _playerManager._playerMovement.PlayerSpec.RotationSpeed = _playerManager._playerMovement.PlayerSpec.LocalRotationSpeed;
            }
            public void StopIteration()
            {
                _playerManager.StopCoroutine(_coroutine);
            }
        }

        #endregion
        #region PoisonMeteor
        private class PoisonMeteor
        {
            public Coroutine _coroutine;
            private readonly PlayerManager _playerManager;

            public PoisonMeteor(PlayerManager playerManager)
            {
                _playerManager = playerManager;
            }
            public IEnumerator DamageToPlayer(float damage = 0)
            {
                while (_playerManager._playerMovement.PlayerSpec.Health > 0)
                {
                    _playerManager.DamagePlayer(damage);
                    yield return new WaitForSeconds(1f);
                }
            }
            public IEnumerator StartPoisonEffect(int duration, float damage)
            {
                while (duration > 0)
                {
                    _playerManager.DamagePlayer(damage);
                    duration--;
                    yield return new WaitForSeconds(1f);
                }
            }
            public void StopIteration()
            {
                _playerManager.StopCoroutine(_coroutine);
            }
        }

        #endregion
    }
}