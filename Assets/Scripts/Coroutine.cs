using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float limitedPositionZ;

    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        rigidBody = GetComponent<Rigidbody>();
        limitedPositionZ = Random.Range(10f, 20f);
    }

    private void Start()
    {
        StartCoroutine(MoveCubeWithDelay());
        StartCoroutine(ChangeMaterial());
    }

    private IEnumerator MoveCubeWithDelay()
    {
        while (transform.position.z < limitedPositionZ)
        {
            yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            rigidBody.AddForce(transform.forward * speed, ForceMode.Force);
        }
    }

    private IEnumerator ChangeMaterial()
    {
        while (transform.position.z < limitedPositionZ)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));

            Color randomColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
            render.material.color = randomColor;
        }
    }
}
