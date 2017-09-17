using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    public int playerId = 0; // The Rewired player id of this character

    public float moveSpeed = 3.0f;

    private Player player; // The Rewired player
    private CharacterController cc;
    private Vector3 moveVector;
    private bool fire1;
    private bool fire2;
    private bool fire3;

    void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);

        // Get the character controller
        cc = GetComponent<CharacterController>();
    }

        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        ProcessInput();
	}

    private void GetInput()
    {
        // Get the input from the Rewired Player. All controlelrs that the Player owns will contribute, so it doesn't matter
        // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

        moveVector.x = player.GetAxis("Move Horizontal"); // get input by name or action id
        moveVector.y = player.GetAxis("Move Vertical");
        fire1 = player.GetButtonDown("Fire1_Square");
        fire2 = player.GetButtonDown("Fire2_Triangle");
        fire3 = player.GetButtonDown("Fire3_Circle");
    }

    private void ProcessInput()
    {
        // Process movement
        if (moveVector.x != 0.0f || moveVector.y != 0.0f)
        {
            cc.Move(moveVector * moveSpeed * Time.deltaTime);
        }
    }
}
