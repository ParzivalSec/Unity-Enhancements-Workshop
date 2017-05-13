using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandlerScript : MonoBehaviour {

    float raycastDistance = 4.5f;

    public GameObject spawnable;
    public GameObject spawnableColor;
    public int particleCount = 10;
    public float particleSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBasicFireworks(CastRayToWorld());
        }
        if (Input.GetMouseButtonDown(1))
        {
            SpawnColorLiquid(CastRayToWorld());
        }
    }
   
    // A raycast for calculating the screen position of a click. In 2D, the raycast distance is actually redundant in Unity.
    Vector3 CastRayToWorld()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + (ray.direction * raycastDistance);
    }
    
    // Spawns objects in a circle exploding outwards like fireworks. Yay!
    void SpawnBasicFireworks(Vector3 point)
    {
        float step = 360.0f / particleCount;
        for(float f = 0; f < 360; f+=step)
        {
            GameObject obj = (GameObject)Instantiate(spawnable, point, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            Vector2 force = new Vector2(0.0f, 1.0f);
            force = Quaternion.AngleAxis(f, Vector3.forward) * Vector2.up;
            obj.GetComponent<Rigidbody2D>().AddForce(force * particleSpeed);
        }
    }

    // Spawns objects which get randomly assigned colors and layers for filtering them.
    void SpawnColorLiquid(Vector3 point)
    {
        GameObject obj = (GameObject)Instantiate(spawnableColor, point, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        Color color = Color.black;
        int rand = Random.Range(0, 3);
        // Color and layer are assigned randomly. NameToLayer lets us use the layer name instead of its ID!
        switch(rand)
        {
            case 0:
                color = Color.red;
                obj.layer = LayerMask.NameToLayer("FilterRed");
                break;
            case 1:
                color = Color.green;
                obj.layer = LayerMask.NameToLayer("FilterGreen");
                break;
            case 2:
                color = Color.blue;
                obj.layer = LayerMask.NameToLayer("FilterBlue");
                break;
        }
        obj.GetComponent<SpriteRenderer>().color = color;
    }


}
