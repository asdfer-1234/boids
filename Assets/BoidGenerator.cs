using UnityEngine;


public class BoidGenerator : MonoBehaviour
{
	public GameObject boid;
	public float range;
	public int count;
	public float velocity;

	private void Start(){
		for(int i = 0; i < count; i++){
			Boid instantiated = Instantiate(boid, Random.insideUnitCircle * range, Quaternion.identity).GetComponent<Boid>();
			instantiated.velocity = Random.insideUnitCircle * velocity;
		}
		BoidController.UpdateAllObjects();
	}
}
