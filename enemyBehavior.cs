using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour

{
    public float speed;
    public float vertSpeed;
    public float horizSpeed;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetComponent<Transform>().position.y < this.GetComponent<Transform>().position.y)
            vertSpeed = -speed;
        else if (target.GetComponent<Transform>().position.y == this.GetComponent<Transform>().position.y)
            vertSpeed = 0;
        else
            vertSpeed = speed;

        if (target.GetComponent<Transform>().position.x < this.GetComponent<Transform>().position.x)
            horizSpeed = -speed;
        else if (target.GetComponent<Transform>().position.x == this.GetComponent<Transform>().position.x)
            horizSpeed = 0;
        else
            horizSpeed = speed;

        GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, vertSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.name=="TrumpetRadius")
            Destroy(this.gameObject);
    }
}
