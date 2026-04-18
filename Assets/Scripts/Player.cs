using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current!=null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos2D= Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touchPos2D.x, touchPos2D.y, Camera.main.nearClipPlane));
            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else if(Mouse.current.leftButton.isPressed)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
