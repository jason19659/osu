// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Game.Configuration;
using osu.Game.Screens.Play;
using osu.Game.Screens.Play.HUD;

namespace osu.Game.Rulesets.Mods
{
    public abstract class ModBlockFail : Mod, IApplicableFailOverride, IApplicableToHUD, IReadFromConfig
    {
        private Bindable<bool> hideHealthBar;
        private HealthDisplay healthDisplay;

        /// <summary>
        /// We never fail, 'yo.
        /// </summary>
        public bool AllowFail => false;

        public void ReadFromConfig(OsuConfigManager config)
        {
            hideHealthBar = config.GetBindable<bool>(OsuSetting.HideHealthBarWhenCantFail);
        }

        public void ApplyToHUD(HUDOverlay overlay)
        {
            healthDisplay = overlay.HealthDisplay;
            hideHealthBar.BindValueChanged(v => healthDisplay.FadeTo(v.NewValue ? 0 : 1, 250, Easing.OutQuint), true);
        }
    }
}
