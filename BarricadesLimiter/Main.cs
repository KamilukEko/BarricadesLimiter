using System.Reflection;
using Rocket.Core.Plugins;
using SDG.Unturned;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace BarricadeLimiter
{
    public class Main : RocketPlugin<Config>
    {
        protected override void Load()
        {
            BarricadeManager.onDeployBarricadeRequested += OnDeployBarricadeRequested;
            
            Logger.Log($"Kamiluk || BarricadeLimiter plugin has been loaded");
        }

        private void OnDeployBarricadeRequested(Barricade barricade, ItemBarricadeAsset asset, Transform hit, ref Vector3 point, ref float angle_x, ref float angle_y, ref float angle_z, ref ulong owner, ref ulong group, ref bool shouldallow)
        {
            if (hit.GetComponent<InteractableVehicle>() == null)
                return;
            
            if (Configuration.Instance.WhitelistedBarricades.Contains(asset.id))
                return;

            shouldallow = false;
        }

        protected override void Unload()
        {
            BarricadeManager.onDeployBarricadeRequested -= OnDeployBarricadeRequested;
            
            Logger.Log($"Kamiluk || BarricadeLimiter plugin has been unloaded");
        }
    }
}