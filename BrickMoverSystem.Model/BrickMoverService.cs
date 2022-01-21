using System.Linq;
using BrickMoverSystem.Model.Contract;

namespace BrickMoverSystem.Model
{
    public class BrickMoverService
    {
        private readonly IBrickRepository _brickRepository;
        private readonly IBucketService _bucketService;
        private readonly IPredictionService _predictionService;
        private readonly IPushTimeCalculator _pushTimeCalculator;
        public BrickMoverService(IBrickRepository brickRepository, IPredictionService predictionService, IPushTimeCalculator pushTimeCalculator, IBucketService bucketService)
        {
            _brickRepository = brickRepository;
            _predictionService = predictionService;
            _pushTimeCalculator = pushTimeCalculator;
            _bucketService = bucketService;
        }

        public void PredictAndPush(IBrick brick)
        {
            // Get Predictions for brick images
            foreach (IImage image in brick.Images)
            {
                IPrediction prediction = _predictionService.GetPrediction(image);
                if (prediction.isValid())
                {
                    image.SetPrediction(prediction);
                }
            }

            // Calculate final Prediction for brick
            if (_predictionService.IsPredictionPossible(brick.Images))
            {
                IPrediction brickPrediction =
                    _predictionService.CalculateBrickPrediction(brick.Images.Select(s => s.Prediction));
                brick.SetPrediction(brickPrediction);
            }

            // Get brick destination(bucket) and calculate pushTime
            IBucket bucket = _bucketService.GetBucketForBrick(brick);
            double pushTime = _pushTimeCalculator.CalculatePushTime(brick, bucket);

            _bucketService.Push(bucket, brick, pushTime);

            // Save Predictions of images and brick
            _brickRepository.Save(brick);
        }

        public void SavePushResult(IPushResultMessage pushResultMessage)
        {
            _brickRepository.SavePushResult(pushResultMessage);
        }
    }
}
