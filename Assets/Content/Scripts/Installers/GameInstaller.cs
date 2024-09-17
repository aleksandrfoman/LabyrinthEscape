using Content.Scripts.Misc;
using Content.Scripts.Services;
using Zenject;
namespace Content.Scripts.Installers
{
    public class GameInstaller : MonoBinder
    {
        public override void InstallBindings()
        {
            BindService<PlayerService>();
            BindService<LevelService>();
            BindService<GameService>();
            BindService<GameCanvasService>();
        }
    }
}