using System.Collections.Generic;
using Rocket.API;

namespace BarricadeLimiter
{
    public class Config : IRocketPluginConfiguration
    {
        public List<ushort> WhitelistedBarricades;

        public void LoadDefaults()
        {
            WhitelistedBarricades = new List<ushort> {1096};
        }
    }
}