using Terraria.ModLoader.Core;
using System.Linq;
using NHAssist.Edits.Vanilla;
using NHAssist.Edits.Calamity;
namespace NHAssist.Edits
{
    internal static class EditLoader
    {
        public static void Load()
        {
            foreach (Type type in
                from x in AssemblyManager.GetLoadableTypes(NHAssist.Instance.Code)
                where !x.IsAbstract && x.GetConstructor(new Type[0]) != null
                select x)
            {
                if (Activator.CreateInstance(type) is MethodEdit edit)
                {
                    if (edit.ShouldApply)
                        edit.Apply();
                }
            }
        }
        public static void ReLoad()
        {
            foreach (Type type in
                from x in AssemblyManager.GetLoadableTypes(NHAssist.Instance.Code)
                where !x.IsAbstract && x.GetConstructor(new Type[0]) != null
                select x)
            {
                if (Activator.CreateInstance(type) is MethodEdit edit)
                {
                    if (edit.ShouldApply && edit.ShouldReApply)
                        edit.ReApply();
                }
            }
        }
        public static void UnLoad()
        {
            QuickReforge.UnLoad();
            OmegaBlueTentacleEdit.UnLoad();
        }
    }
}

