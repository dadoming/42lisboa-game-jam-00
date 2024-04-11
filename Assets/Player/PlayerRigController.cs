using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerRigController : MonoBehaviour
{
  public const float walkSpeed = 10.0f;
  public float speed = 0;
  public float jumpHeight = 1.0f;
  private PlayerKeybindsController binds;

  public GameObject body;
  public Light2D selfLight;
  private Animator animator;
  private SpriteRenderer spriteRenderer;
  private Rigidbody2D rb;
  public Vector2 groundOffset = new Vector2(0, -0.5f);
  public bool isGrounded = false;
  public float groundCheckDistance = 0.2f;

  // Start is called before the first frame update
  void Start()
  {
    binds = GetComponent<PlayerKeybindsController>();
    animator = body.GetComponent<Animator>();
    spriteRenderer = body.GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
    animator.SetFloat("jumpSpeed", jumpHeight);
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 origin = transform.position + (Vector3)groundOffset;
    RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance);
    isGrounded = hit.collider != null;
    Debug.DrawRay(origin, Vector2.down * groundCheckDistance, isGrounded ? Color.green : Color.red);
    animator.SetBool("isGrounded", isGrounded);
    if (Input.GetKeyDown(binds.jump) && isGrounded)
    {
      animator.SetTrigger("jump");
      isGrounded = false;
      rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }
    else if (Input.GetKey(binds.runningLeft))
    {
      transform.position += speed * Time.deltaTime * Vector3.left;
      spriteRenderer.flipX = true;
      selfLight.transform.localScale = new Vector2(-1, 1);
      animator.SetBool("running", true);
    }
    else if (Input.GetKey(binds.runningRight))
    {
      transform.position += speed * Time.deltaTime * Vector3.right;
      spriteRenderer.flipX = false;
      selfLight.transform.localScale = new Vector2(1, 1);
      animator.SetBool("running", true);
    }
    else if (animator.GetBool("running") == true)
    {
      animator.SetBool("running", false);
    }
  }
  void OnCollisionEnter(Collision collision)
  {
    isGrounded = true;
    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
      return;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
