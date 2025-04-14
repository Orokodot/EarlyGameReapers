using BepInEx;
using BepInEx.Logging;
using Bloodstone.API;
using ProjectM;
using Unity.Entities;

namespace EarlyGameReapers1
{
    [BepInPlugin("com.yourname.bonereaperspawner", "Bone Reaper Spawner", "1.0.0")]
    public class BoneReaperSpawner : BaseUnityPlugin
    {
        private static readonly PrefabGUID BoneReaperPrefab = new PrefabGUID(-152327780); // Your Bone Reaper ID

        private void Awake()
        {
            Logger.LogInfo("Bone Reaper Spawner loaded!");
            PluginSystems.Register(OnUpdate);
        }

        private void OnUpdate(World world)
        {
            if (!VWorld.IsClient) return;
            if (!Input.GetKeyDown(UnityEngine.KeyCode.F8)) return; // Press F8 to spawn

            var userEntity = VWorld.ClientLocalUser.UserEntity;
            var inventory = VWorld.Server.EntityManager.GetComponentData<Inventory>(userEntity);

            InventoryUtilitiesServer.TryAddItem(inventory.InventoryEntity, BoneReaperPrefab, 1, out var _);

            Logger.LogInfo("Bone Reaper spawned into your inventory!");
        }
    }
}
