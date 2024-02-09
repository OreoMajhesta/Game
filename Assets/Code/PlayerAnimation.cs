using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        UpdateSpriteDirection(moveDirection);
    }

    void UpdateSpriteDirection(Vector3 moveDirection)
    {
        // Menentukan arah karakter dan memicu trigger animator sesuai arah
        if (moveDirection.x > 0)
        {
            SetAnimatorTrigger("kanan");
        }
        else if (moveDirection.x < 0)
        {
            SetAnimatorTrigger("kiri");
        }
        else if (moveDirection.y > 0)
        {
            SetAnimatorTrigger("atas");
        }
        else if (moveDirection.y < 0)
        {
            SetAnimatorTrigger("bawah");
        }
        else
        {
            // Tidak bergerak, matikan semua trigger
            ResetAnimatorTriggers();
        }
    }

    void SetAnimatorTrigger(string triggerName)
    {
        // Memicu trigger pada animator
        if (animator != null)
        {
            ResetAnimatorTriggers();
            animator.SetTrigger(triggerName);
        }
    }

    void ResetAnimatorTriggers()
    {
        // Menonaktifkan semua trigger pada animator
        if (animator != null)
        {
            animator.ResetTrigger("kanan");
            animator.ResetTrigger("kiri");
            animator.ResetTrigger("atas");
            animator.ResetTrigger("bawah");
        }
    }
}
