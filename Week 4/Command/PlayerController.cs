using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MoveCommand _moveCommand;

    private void Start()
    {
        // Attach a rigidbody component to the object this script is attached to
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }

        // Create a new MoveCommand with the attached rigidbody and movement direction
        Vector3 movement = new Vector3(1, 0, 0);
        _moveCommand = new MoveCommand(rigidbody, movement);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _moveCommand.Execute();
        }
    }
}
