using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private float _velocity = 10f;

    void Update()
    {
        var move = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
        }

        var direction = new Vector3(move, 0);
        transform.position += direction * (_velocity * Time.deltaTime);
    }
}
