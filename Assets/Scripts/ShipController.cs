using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float velocity;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            this.transform.position += Vector3.left * (velocity * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            this.transform.position += Vector3.right * (velocity * Time.deltaTime);
            
        }

        if (Input.GetKeyDown("space"))
        {
            GameObject bulletObject = GameObject.Instantiate<GameObject>(bulletPrefab);
            bulletObject.transform.position = this.transform.position + Vector3.up;
        }
    }
}
