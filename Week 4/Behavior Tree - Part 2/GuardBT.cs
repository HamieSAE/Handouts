using BehaviorTree;

public class GuardBT : Tree
{
    // Array of waypoints for the guard to patrol
    public UnityEngine.Transform[] waypoints;
    // Speed at which the guard moves
    public static float speed = 2f;
     // Range of field of view for the guard
    public static float fovRange = 6f;
     // Overridden method to set up the Behavior Tree
    protected override Node SetUpTree()
    {
         // Root node is a selector node with three children:
        Node root = new Selector(new List<Node>
        {
            // 1. Sequence node that checks if an enemy is in attack range and then attacks the enemy
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
            }),
        // 2. Sequence node that checks if an enemy is in field of view range and then moves
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}