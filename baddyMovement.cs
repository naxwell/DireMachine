﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class baddyMovement : MonoBehaviour {
	
		Transform player;               // Reference to the player's position.    
		NavMeshAgent nav;               // Reference to the nav mesh agent.


		void Awake ()
		{
			// Set up the references.
			player = GameObject.Find ("Player").transform;
			nav = GetComponent <NavMeshAgent> ();
		}


		void Update ()
		{
		
				nav.SetDestination (player.position);
			
			
		}
	}
