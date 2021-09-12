using UnityEngine.Rendering.PostProcessing;

namespace Code.Controllers
{
    public class LowSpeedPostPrController
    {
        private PostProcessVolume _ppv;

        public LowSpeedPostPrController(PostProcessVolume ppv)
        {
            _ppv = ppv;
        }
        
        public void TurnOn(bool turn)
        {
            _ppv.enabled = turn;
        }
    }
}