using KSP.UI.Screens;
using UnityEngine;

namespace SaturatableRW
{
    [KSPScenario(ScenarioCreationOptions.AddToAllGames, new[] { GameScenes.FLIGHT })]
    public class ToolbarButtonScenario : ScenarioModule
    {
        private ApplicationLauncherButton toggleRWButton = null;

        public override void OnLoad(ConfigNode node)
        {
            Texture2D texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);             // Hardcode = bad. Sry.
            ImageConversion.LoadImage(texture, System.IO.File.ReadAllBytes("GameData/RW Saturatable/SSRW_ToolbarIco.png"));

            toggleRWButton = ApplicationLauncher.Instance.AddModApplication(null, null, null, null, null, null,
                    ApplicationLauncher.AppScenes.FLIGHT, texture);

            toggleRWButton.onLeftClick = () => Window.Instance.showWindow = !Window.Instance.showWindow;
        }

        private void OnDestroy()
        {
            ApplicationLauncher.Instance.RemoveModApplication(toggleRWButton);
        }
    }
}
