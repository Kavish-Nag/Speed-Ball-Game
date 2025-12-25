using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject rightPos, leftPos;
    bool changePosition, startGame;
    public GameObject deadPrefab;
    public float speed;

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);

        if (changePosition == true && startGame == true)
        {
            // Move Right Smoothly
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(rightPos.transform.position.x, transform.position.y, transform.position.z),
                7f * Time.deltaTime
            );
        }

        if (changePosition == false && startGame == true)
        {
            // Move Left Smoothly
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(leftPos.transform.position.x, transform.position.y, transform.position.z),
                7f * Time.deltaTime
            );
        }

        if (Input.GetMouseButtonDown(0))
        {
            startGame = true;

            if (changePosition == false)
                changePosition = true;
            else
                changePosition = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            transform.gameObject.SetActive(false);
            for(int i=0; i < 15; i++)
            {
                Instantiate(deadPrefab,transform.position,Quaternion.identity);
            }
        }
        if (other.tag == "finish")
        {
            Debug.Log("You Win");
        }   
    }
}
