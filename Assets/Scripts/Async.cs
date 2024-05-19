using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Async : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Renderer render;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float limitedPositionZ;

    private CancellationTokenSource cancellationTokenSource;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        rigidBody = GetComponent<Rigidbody>();
        limitedPositionZ = Random.Range(10f, 20f);
    }

    private void Start()
    {
        cancellationTokenSource = new CancellationTokenSource();
        MoveCubeWithDelay();
        ChangeColor();
    }

    private async void MoveCubeWithDelay()
    {
        try
        {
            while (transform.position.z < limitedPositionZ)
            {
                await Task.Delay(Random.Range(0, 500), cancellationTokenSource.Token);

                rigidBody.AddForce(transform.forward * speed, ForceMode.Force);
            }
        }
        catch (System.OperationCanceledException)
        {
            Debug.Log("Async operation canceled.");
        }
    }

    private async void ChangeColor()
    {
        try
        {
            while (transform.position.z < limitedPositionZ)
            {
                await Task.Delay(Random.Range(1000, 3000), cancellationTokenSource.Token);

                Color randomColor = new Color(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f)
                );

                render.material.color = randomColor;
            }
        }
        catch (System.OperationCanceledException)
        {
            Debug.Log("Async operation canceled.");
        }

    }

    private void OnDestroy()
    {
        if (cancellationTokenSource != null)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }

    }
}
