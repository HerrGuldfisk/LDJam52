using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

	public Transform player;
	public Vector3 offset = new Vector3(0, 0 , -1);
	private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
		cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
		cam.transform.position = player.position + offset;
    }
}
