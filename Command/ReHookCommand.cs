using NHAssist.Edits;
namespace NHAssist.Command
{
    public class ReHookCommand : ModCommand
    {
        public override string Command => "rehook";

        public override string Usage => "/rehook";

        public override string Description =>
            @"Sometimes, mod hooks mysteriously disappear.
This command reloads the hooks in NHAssist without having to reload all mods.";

        public override CommandType Type => CommandType.Chat;

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            EditLoader.ReLoad();
        }
    }
}

