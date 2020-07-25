using Assets.Code.Model;
using Assets.Code.View;

namespace Assets.Code.Helper
{
    public class Player
    {
        public IPlayerView PlayerView { get; }
        public PlayerModel PlayerModel { get; }

        public Player(IPlayerView playerView, PlayerModel playerModel, int id)
        {
            PlayerView = playerView;
            PlayerModel = playerModel;

            PlayerView.Id = id;
            PlayerModel.Id = id;
        }
    }
}