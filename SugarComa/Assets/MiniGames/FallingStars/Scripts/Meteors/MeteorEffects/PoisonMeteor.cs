using Assets.MiniGames.FallingStars.Scripts.GameManaging;
using Assets.MiniGames.FallingStars.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.MiniGames.FallingStars.Scripts.Meteors.MeteorEffects
{
    public class PoisonMeteor : MonoBehaviour
    {
        #region Properties
        private bool isPlayerIn;
        private Coroutine insideCoroutine, outsideCoroutine;
        #region SeralizeFields
        [SerializeField] private int _duration = 3;
        [SerializeField] private int _poisonDuration = 5;
        [SerializeField] private float _damage;
        #endregion
        #endregion

        #region OtherComponents
        [SerializeField] Meteor _meteor;
        #endregion

        private void Awake()
        {
            _meteor.OnMeteorDisable += ResetMeteor;
        }
        private void OnEnable()
        {
            StartCoroutine(CountdownTimer());
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerIn = true;
                if(outsideCoroutine != null) StopCoroutine(outsideCoroutine);
                insideCoroutine = StartCoroutine(Poison(_damage, other.GetComponent<PlayerSpecs>()));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerIn = false;
                if (insideCoroutine != null) StopCoroutine(insideCoroutine);
                outsideCoroutine = StartCoroutine(other.GetComponent<PlayerSpecs>().PoisonEffect(_poisonDuration, _damage));
            }
        }

        private IEnumerator Poison(float damage, PlayerSpecs playerSpecs)
        {
            while (isPlayerIn)
            {
                playerSpecs.DamagePlayer(damage);
                yield return new WaitForSeconds(1f);
            }
        }

        private IEnumerator CountdownTimer()
        {
            yield return new WaitForSeconds(_duration);
            MiniGameController.Instance.AddToPool(_meteor);
        }

        private void ResetMeteor()
        {
            print("poisonmeteor resetted");
            StopAllCoroutines();
        }
    }
}