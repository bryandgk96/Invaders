using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Action onEnemyDestroyed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.GetComponent<BulletController>() != null)
        {
            onEnemyDestroyed();
            GameObject.Destroy((this.gameObject));
            GameObject.Destroy(c.gameObject);
        }
        if (c.gameObject.GetComponent<ShipController>() != null)
        {
            GameObject.Destroy((this.gameObject));
            GameObject.Destroy(c.gameObject);
        }
        //Debug.Log(c.name);
    }
}
