using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Player2DController : MonoBehaviour
{
	public float speed;

	private Rigidbody2D body;
	private Vector2 moveVelocity;

	private void  Start() //находим объект
	{
		body = GetComponent<Rigidbody2D>();
	}


	void Update() //движение
	{
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput.normalized * speed;
	}



    void FixedUpdate () //делаем движение плавным
    {
		body.MovePosition(body.position + moveVelocity * Time.fixedDeltaTime);
    }
}
