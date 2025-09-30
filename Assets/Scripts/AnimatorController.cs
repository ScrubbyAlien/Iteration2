using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void SetBoolTrue(string boolName) {
        animator.SetBool(boolName, true);
    }
    public void SetBoolFalse(string boolName) {
        animator.SetBool(boolName, false);
    }
    public void SetFloatPositive(string floatName) {
        animator.SetFloat(floatName, 1f);
    }
    public void SetFloatNegative(string floatName) {
        animator.SetFloat(floatName, -1f);
    }
    public void SetFloatZero(string floatName) {
        animator.SetFloat(floatName, 0f);
    }
}