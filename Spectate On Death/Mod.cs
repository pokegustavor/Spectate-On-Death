using PulsarModLoader;

namespace Spectate_On_Death
{
    public class Mod : PulsarMod
    {
        public override string Version => "1.0";

        public override string Author => "pokegustavo";

        public override string ShortDescription => "Enables Spectator when dead";

        public override string Name => "Spectator Mode";

        public override string HarmonyIdentifier()
        {
            return "pokegustavo.speactatormode";
        }
    }
}
