using UnityEngine;


public class BoidGenerator : MonoBehaviour
{
	public GameObject boid;
	public float range;
	public int count;
	public float velocity;
	public float obstacleRadius;
	public GameObject obstacle;
	public int obstacleCount;

	private void Start(){
		for(int i = 0; i < count; i++){
			Boid instantiated = Instantiate(boid, Random.insideUnitCircle * range, Quaternion.identity).GetComponent<Boid>();
			instantiated.velocity = Random.insideUnitCircle * velocity;
		}
		for(int i = 0; i < obstacleCount; i++){
			transform.position = Vector3.zero;
			transform.Rotate(0, 0, 360 / obstacleCount);
			transform.Translate(obstacleRadius, 0, 0);
			Instantiate(obstacle, transform.position, Quaternion.identity);
		}
		BoidController.UpdateAllObjects();
	}
}
