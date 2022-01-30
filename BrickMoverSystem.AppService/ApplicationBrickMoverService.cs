using System.Threading.Tasks;
using BrickHandler.Model;

namespace BrickHandler.AppService
{
    public class ApplicationBrickMoverService
    {
        private BrickMoverService _brickMoverService;

        public ApplicationBrickMoverService(BrickMoverService brickMoverService)
        {
            _brickMoverService = brickMoverService;
        }

        public async Task PredictAndPush(IBrick brick, IRun run)
        {
            await _brickMoverService.PredictAndPush(brick);
        }

        public void Evaluate(IPushResult pushResult)
        {
            _brickMoverService.SavePushResult(pushResult);
        }
    }
}
