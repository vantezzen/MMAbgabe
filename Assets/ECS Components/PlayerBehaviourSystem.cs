using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class PlayerBehaviourSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float elapsedTime = (float)Time.ElapsedTime;

        Entities
            .ForEach((ref Translation trans, ref PlayerComponent player, ref Rotation rot) =>
        {
            player.rotationAngle += hor / 10;

            float3 targetDirection = new float3(math.sin(player.rotationAngle), 0, math.cos(player.rotationAngle));
            rot.Value = quaternion.LookRotationSafe(targetDirection, new Vector3(0, 1, 0));

            trans.Value += targetDirection * player.speed * ver;
        }).Schedule();
    }
}
