using UnityEngine;
using System.Linq;

public class BoidController : MonoBehaviour
{
	public static Boid[] allBoids;
	public static Transform[] allObstacles;

	
	private void Update(){
		foreach(Boid i in allBoids){
			i.Snapshot();
		}
		foreach(Boid i in allBoids){
			i.Flock();
		}

	}

	public static void UpdateAllObjects(){
		allBoids = (from GameObject i in GameObject.FindGameObjectsWithTag("Boid") select i.GetComponent<Boid>()).ToArray();
		allObstacles = (from GameObject i in GameObject.FindGameObjectsWithTag("Obstacle") select i.transform).ToArray();
	}
	
}
