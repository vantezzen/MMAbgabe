using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class SpawnCollectableSystem : SystemBase
{
    EntityCommandBufferSystem barrier => World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();

    protected override void OnUpdate(){
        var commandBuffer = barrier.CreateCommandBuffer().AsParallelWriter();

        Entities
            .ForEach((Entity entity, int entityInQueryIndex, ref SpawnCollectableComponent spawnComponent) =>
            {
                Random rnd = new Random(100);
                for (int x = 0; x < spawnComponent.anzahlDerCollectables; x++){
                    Entity entityInstance = commandBuffer.Instantiate(entityInQueryIndex, spawnComponent.collectablePrefab);
                    // Place the instantiated in a grid with some noise
                    float3 position = new float3(rnd.NextFloat(-5, 5), 0.05f, rnd.NextFloat(-5, 5));
                    commandBuffer.SetComponent(entityInQueryIndex, entityInstance, new Translation { Value = position });
                }
                
                commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            })
            .ScheduleParallel();

        barrier.AddJobHandleForProducer(Dependency);
    }
}
