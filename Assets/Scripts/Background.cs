using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float yWrap;

    // Update is called once per frame
    void LateUpdate() {
        transform.Translate(Vector3.down * (scrollSpeed * Time.deltaTime));
        if (transform.position.y <= yWrap) {
            transform.Translate(Vector3.up * -transform.position.y);
        }
    }
}