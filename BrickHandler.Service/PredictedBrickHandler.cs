using BrickHandler.RabbitMQAdapter.MessageHandling;
using System.Threading.Tasks;
using BrickHandler.Model;
using BrickHandler.Model.Contract;

namespace BrickHandler.Service
{
    public class PredictedBrickHandler : IMessageHandler<PredictedBrickMessage>
    {
        private readonly IBucketService _bucketService;
        private readonly IPushTimeCalculator _pushTimeCalculator;
        private readonly IBrickRepository _brickRepository;
        public PredictedBrickHandler(IBucketService bucketService, IPushTimeCalculator pushTimeCalculator, IBrickRepository brickRepository)
        {
            _bucketService = bucketService;
            _pushTimeCalculator = pushTimeCalculator;
            _brickRepository = brickRepository;
        }
        
        public async Task Handle(PredictedBrickMessage message)
        {
            IBrick brick = new Brick(message.BrickId, message.BrickPrediction, message.ImagePredictions, message.LastPosition, message.Speed);
            IBucket bucket = _bucketService.GetBucketForBrick(brick.BrickPrediction.Part.No, brick.BrickPrediction.Color.Id);
            brick.SetBucket(bucket);
            await _brickRepository.SaveAsync(brick);

            double pushTime = _pushTimeCalculator.CalculatePushTime(bucket.Distance, brick.LastPosition, brick.Speed);
            _bucketService.Push(bucket.Id, brick, pushTime);
        }
    }
}
