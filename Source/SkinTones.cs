using Verse;
using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace InclusiveSkinTones
{
    public class InclusiveSkinTones : Mod
    {
        public InclusiveSkinTones(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("h2forge.InclusiveSkinTones");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(ShaderUtility), nameof(ShaderUtility.GetSkinShader))]
    class Patch1
    {
        static void Postfix(Pawn pawn, ref Shader __result)
        {
            if (PawnSkinColors.IsDarkSkin(pawn.story.SkinColor))
            {
                __result = ShaderDatabase.Cutout;
            }
        }
    }
}