using UnityEngine.Rendering.PostProcessing;

namespace Code.Controllers
{
    public sealed class FastSpeedPostPrController
    {
        private PostProcessVolume _ppv;

        public FastSpeedPostPrController(PostProcessVolume ppv)
        {
            _ppv = ppv;
        }
        
        public void TurnOn(bool turn)
        {
            _ppv.enabled = turn;
        }
    }
}