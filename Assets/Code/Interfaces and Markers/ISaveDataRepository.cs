using Code.Player.Player;

namespace Code.Interfaces_and_Markers
{
    public interface ISaveDataRepository
    {
        void Save(PlayerBall player);
        void Load(PlayerBall player);
    }
}