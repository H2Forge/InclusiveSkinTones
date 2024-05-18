using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace SkinTones
{
    public class InclusiveSkinTonesMod : Mod
    {
        public InclusiveSkinTonesMod(ModContentPack content) : base(content)
        {
            
            var harmony = new Harmony("h2forge.InclusiveSkinTones");
            harmony.PatchAll();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            var listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("Red Skin Tone Shader", ref SkinTonesSettings.ApplySkinShader, "Toggle on/off the red shadow skin shader for all skin tones.");
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        
        public override string SettingsCategory()
        {
            return "InclusiveSkinTones";
        }
    }

    [HarmonyPatch(typeof(ShaderUtility), nameof(ShaderUtility.GetSkinShader))]
    class Patch1
    {

        static void Postfix(Pawn pawn, ref Shader __result)
        {
            if  (!SkinTonesSettings.ApplySkinShader|| PawnSkinColors.IsDarkSkin(pawn.story.SkinColor))
            {
                __result = ShaderDatabase.Cutout;
            }
        }
    }
}