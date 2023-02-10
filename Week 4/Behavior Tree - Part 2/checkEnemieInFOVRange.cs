using BehaviorTree;

public class CheckEnemyInFOVRange : Node
{
    private static int _enemyLayerMask = 1 << 6;
    // layer mask to represent enemy layer, it is a bit shift operation to select 6th layer

    private Transform _transform;
    private Animator _animator;

    public CheckEnemyInFOVRange(Transform transform)
    {
        _transform = transform; // store the transform component of the object
        _animator = transform.GetComponent<Animator>(); // store the animator component of the object
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target"); // get the data "target" stored in the parent node
        if (t == null) // if the data is not stored
        {
            Collider[] colliders = Physiscs.OverlapSphere(
                -transform.position, GuardBT.fovRange, _enemyLayerMask);
                // use physics overlap sphere to detect colliders within the fov range and enemy layer
           
            if(colliders.Length > 0) // if there are colliders detected
            {
                parent.parent.SetData("target", colliders[0].transform);
                // store the first collider's transform in the parent node's parent as the "target"
                _animator.SetBool("Walking", true);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}