using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour 
{

	public float maxSpeed;

	bool grounded = false;
	float groundCheckRadius=0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	Rigidbody2D myRB;
	Animator myAnim;
	bool facingRight;



	void Start () 
	{
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		facingRight = true;

	}
	void Update()
	{
		if(grounded&&Input.GetAxis("Jump")>0)
		{
				grounded=false;
				myAnim.SetBool("isGrounded",grounded);
			myRB.AddForce(new Vector2(0,jumpHeight));
					
			}

	}

	


	void FixedUpdate () {


		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool("isGrounded",grounded);

		myAnim.SetFloat ("verticalSpeed", myRB.velocity.y);



		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);

		if (move > 0 && !facingRight) 
		{
			flip ();
		}
			else if(move <0&&facingRight)
			{
				flip();
			}

		}
		
      void flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

}
