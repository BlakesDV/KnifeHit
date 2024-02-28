using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipThrow : MonoBehaviour
{
    private PlayerActs acts;

    [SerializeField]
    private Vector2 throwForce;
    private bool isActive = true;
    private Rigidbody2D rb;
    private BoxCollider2D shipCollider;

    private void Awake()
    {
        acts = new PlayerActs();
        acts.Enable();
        rb = GetComponent<Rigidbody2D>();
        shipCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        acts.Shoot.Throw.performed += Throw;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && isActive) 
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse); //add force to rb
            
        }
    }

    private void Throw(InputAction.CallbackContext context)
    {
        transform.Translate(Vector2.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isActive)  return; 
        isActive = false;

        if(collision.collider.tag == "Planet")
        {
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(collision.collider.transform); //une el collider de la ship con el planeta al hacerlo parent
            shipCollider.offset = new Vector2(shipCollider.offset.x, -0.2f);
            shipCollider.size = new Vector2(shipCollider.size.x, 0.25f);
            GameController.Instance.OnSuccessfulKnifeHit();
        }
        else if(collision.collider.tag == "Ship")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            GameController.Instance.StartGameOverSequence(false);
        }
        //Destroy(gameObject);
    }
}
