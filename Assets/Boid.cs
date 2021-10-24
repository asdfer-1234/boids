using System;
using System.Linq;
using UnityEngine;

public class Boid : MonoBehaviour
{
	private Vector2 previousPosition;
	private Vector2 previousVelocity;
	public Vector2 velocity;
	public float range;
	public float obstacleRange;
	public float groupStrength;
	public float alignStrength;
	public float spreadStrength;
	public float obstacleStrength;
	public float maxSpeed;
	public float minSpeed;

	private Boid[] nearbyBoids;

	public void Snapshot(){
		previousPosition = (Vector2) transform.position;
		previousVelocity = velocity;
	}

	public void Flock(){
		
		nearbyBoids = GetNearbyBoids(range); // optimize
		
		Align();
		Group();
		Spread(); // the interaction family
		AvoidObstacles();
	
		// limit speed
		if(velocity.magnitude > maxSpeed){
			velocity = velocity.normalized * maxSpeed;
		}
		else if(velocity.magnitude < minSpeed){
			velocity = velocity.normalized * minSpeed;
		}
		
		// the movement
		transform.Translate(velocity.x, velocity.y, 0);

		
	}
	private void Align(){
		Vector2 total = Vector2.zero;
		foreach(Boid i in nearbyBoids){
			total += i.previousVelocity;

		}

		velocity += (total / nearbyBoids.Length - velocity).normalized * alignStrength;
	}
	private void Group(){
		Vector2 total = Vector2.zero;
		foreach(Boid i in nearbyBoids){
			total += i.previousPosition - (Vector2)transform.position;
		}

		velocity += (total / nearbyBoids.Length).normalized * groupStrength;
	}
	private void Spread(){
		Vector2 total = Vector2.zero;
		foreach(Boid i in nearbyBoids){
			Vector2 relativePosition = i.previousPosition - (Vector2)transform.position;
			total += (relativePosition - relativePosition.normalized * range);
		}

		velocity += (total / nearbyBoids.Length).normalized * spreadStrength;
	}

	private void AvoidObstacles(){
		Transform[] nearbyObstacles = GetNearbyObstacles(obstacleRange);
		
		Vector2 total = Vector2.zero;
		foreach(Transform i in nearbyObstacles){
			Vector2 relativePosition = (Vector2) (i.transform.position - transform.position);
			total += (relativePosition - relativePosition.normalized * range);
		}

		velocity += (total / nearbyObstacles.Length).normalized * obstacleStrength;
	}

	private Boid[] GetNearbyBoids(float range){
		return (from Boid i in BoidController.allBoids where Vector2.Distance(transform.position, i.previousPosition) <= range && this != i select i).ToArray();
	}

	private Transform[] GetNearbyObstacles(float range){
		return (from Transform i in BoidController.allObstacles where Vector2.Distance(transform.position, i.transform.position) <= range select i).ToArray();
	}
}
/*
Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Terrible Code */