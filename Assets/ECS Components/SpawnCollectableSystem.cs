using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Transforms;

public class SpawnCollectableSystem : SystemBase
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;
    protected override void OnCreate(){
        // Cache the BeginInitializationEntityCommandBufferSystem in a field, so we don't have to create it every frame
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate(){
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer();
        Entities
            .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach((Entity entity, int entityInQueryIndex, in SpawnCollectableComponent spawnComponent) =>
            {
                for (var x = 0; x < spawnComponent.anzahlDerCollectables; x++){
                    Entity entityInstance = commandBuffer.Instantiate(spawnComponent.collectablePrefab);
                    // Place the instantiated in a grid with some noise
                    float3 position = new float3(UnityEngine.Random.Range(-5, 5), 2, UnityEngine.Random.Range(-5, 5));
                    commandBuffer.SetComponent(entityInstance, new Translation { Value = position });
                }
                commandBuffer.DestroyEntity(entity);
            }).ScheduleParallel();
        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
