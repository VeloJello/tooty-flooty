using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float horizVelocity;
    public float vertVelocity;

    [SerializeField] AudioClip[] fluteSounds;

    public int hitPoints;
    public int maxHitPoints;

    public bool hasFlute;

    public GameObject trumpetArea;

    bool activity;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
        trumpetArea.SetActive(false);
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            vertVelocity = speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            vertVelocity = -speed;
        else
            vertVelocity = 0;

        //horizontal velocity handling
        if (Input.GetKey(KeyCode.RightArrow))
            horizVelocity = speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            horizVelocity = -speed;
        else
            horizVelocity = 0;

        if (Input.GetKeyDown(KeyCode.Space))
            activity = true;

        if (activity && hasFlute)
        {
            trumpetArea.SetActive(true);
            AudioClip clip = fluteSounds[Random.Range(0, fluteSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
        else
            trumpetArea.SetActive(false);

        if (hitPoints <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        activity = false;
        GetComponent<Rigidbody2D>().velocity = new
            Vector2(horizVelocity, vertVelocity);
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
            hitPoints--;

        if (hit.gameObject.name == "Flute")
            hasFlute = true;
    }
}