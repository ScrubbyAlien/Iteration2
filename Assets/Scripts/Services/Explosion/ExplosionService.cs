using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

public class ExplosionService : MonoBehaviour
{
    [SerializeField]
    private Locator<ExplosionService> locator;
    [SerializeField]
    private ExplosionFactory factory;

    private void Start() {
        RegisterService();
    }

    private void RegisterService() {
        locator.Register(this);
    }

    public void PlayExplosion(Vector2 position, ExplosionParameters p) {
        StartCoroutine(ExplosionCoroutine(position, p.radius, p.rate, p.duration));
    }

    private IEnumerator ExplosionCoroutine(Vector2 position, float radius, float rate, float duration) {
        if (rate <= 0) {
            Debug.LogWarning("Rate of explosions must be greater than zero");
            yield return null;
        }

        float startTime = Time.time;
        float secondsBetween = 1 / rate;
        while (Time.time <= startTime + duration) {
            Explosion explosion = factory.GetProduct();
            Vector3 randomPosInCircle = position + Random.insideUnitCircle * radius;
            explosion.transform.position = new Vector3(
                randomPosInCircle.x, randomPosInCircle.y,
                explosion.transform.position.z
            );
            yield return new WaitForSeconds(secondsBetween);
        }
    }

    [Serializable]
    public struct ExplosionParameters
    {
        public float radius;
        public float rate;
        public float duration;
    }
}