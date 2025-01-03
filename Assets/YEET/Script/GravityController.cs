using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using YEET;

public class GravityController : MonoBehaviour
{
    [SerializeField] RotateScene rotateScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotateScene.Rotate();
        }
    }
}
