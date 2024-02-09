using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 previousPosition;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Mendapatkan posisi baru setelah pergerakan
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // Memindahkan karakter ke posisi baru
        transform.position = newPosition;

        // Menyimpan posisi sebelumnya sebelum pergerakan
        previousPosition = transform.position;
    }
}
