namespace Code.SaveLoad
{
    public interface ISaveDataRepository
    {
        void Save(RollaBall.Player.PlayerBall player);
        void Load(RollaBall.Player.PlayerBall player);
    }
}