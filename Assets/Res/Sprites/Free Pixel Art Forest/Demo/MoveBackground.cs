using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBase {

	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;

	void Update ()
	{
		x = transform.position.x;
		x += speed * Time.deltaTime;
		position = new Vector3 (x, position.y, position.z);

		if (x <= PontoDeDestino){

			x = PontoOriginal;
			position = new Vector3 (x, position.y, position.z);
		}
	}
}