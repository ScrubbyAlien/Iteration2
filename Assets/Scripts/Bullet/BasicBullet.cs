using UnityEngine;
using UnityEngine.Pool;

public class BasicBullet : MonoBehaviour, IBullet
{
    public Vector2 direction {
        get => transform.up;
        set => transform.up = value;
    }

    public GameObject gameObjectRef => gameObject;
    public ObjectPool<IBullet> pool { get; set; }

    [SerializeField]
    private float speed;

    private void Update() {
        if (gameObject.activeInHierarchy) transform.Translate(direction * (speed * Time.deltaTime));
    }

    public void Activate() {
        gameObject.SetActive(true);
    }
    public void Deactivate() {
        gameObject.SetActive(false);
    }

    // todo: make bullets deal damage
}