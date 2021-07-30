using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float velocity;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * (velocity * Time.deltaTime);

        if (this.transform.position.y >= 10)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
