using UnityEngine;

public class MobGroundCheck : MonoBehaviour
{
    [Header("Ground Check Settings")]
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 raycastOffset = Vector3.zero;

    private bool isGrounded;

    // Public property to access grounded status
    public bool IsGrounded => isGrounded;

    private void Update()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        // Cast a ray downward to check for ground
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position + raycastOffset,
            Vector2.down,
            groundCheckDistance,
            groundLayer);

        // Alternative for 3D:
        // RaycastHit hit;
        // bool hasHit = Physics.Raycast(
        //     transform.position + raycastOffset,
        //     Vector3.down,
        //     out hit,
        //     groundCheckDistance,
        //     groundLayer);

        isGrounded = hit.collider != null;

        // Optional debug visualization
        Debug.DrawRay(transform.position + raycastOffset, Vector3.down * groundCheckDistance,
                     isGrounded ? Color.green : Color.red);
    }
}
