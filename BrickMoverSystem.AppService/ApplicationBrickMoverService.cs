using BrickMoverSystem.Model;

namespace BrickMoverSystem.AppService
{
    public class ApplicationBrickMoverService
    {
        private BrickMoverService _brickMoverService;

        public ApplicationBrickMoverService(BrickMoverService brickMoverService)
        {
            _brickMoverService = brickMoverService;
        }

        public void PredictAndPush(IBrick brick)
        {
            _brickMoverService.PredictAndPush(brick);
        }

        public void Evaluate(IPushResultMessage pushResultMessage)
        {
            _brickMoverService.SavePushResult(pushResultMessage);
        }
    }
}
