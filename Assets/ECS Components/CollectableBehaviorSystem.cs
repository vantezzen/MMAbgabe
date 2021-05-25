using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class CollectableBehaviorSystem : SystemBase
{
    
    protected override void OnUpdate()
    {
        Entities
            .ForEach((ref Rotation rot, ref CollectedComponent coll) =>
            {

            }
            ).Schedule();
    }
}
