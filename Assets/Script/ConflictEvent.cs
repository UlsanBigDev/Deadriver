using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConflictEvent : MonoBehaviour
{
    MeshRenderer mesh;
    int carHp = 10;

    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Car")
        {
            carHp--;
            Debug.Log(carHp);
        }
    }
}