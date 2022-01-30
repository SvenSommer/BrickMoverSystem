using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrickHandler.Model.Contract;

namespace BrickHandler.Model
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

        public async Task PredictAndPush(IBrick brick)
        {
            await GetAndSaveImagePredictions(brick);

            if (_predictionService.IsPredictionAboveMinConfidences(brick.Images)) 
                CalculateAndSetBrickPrediction(brick);

            IBucket bucket = _bucketService.GetBucketForBrick(brick);
            double pushTime = _pushTimeCalculator.CalculatePushTime(brick.Sightings, bucket.Distance);

            _bucketService.Push(bucket.Id, brick, pushTime);

            _brickRepository.Save(brick);
        }

        private void CalculateAndSetBrickPrediction(IBrick brick)
        {
            IEnumerable<IPrediction> imagePredictions = brick.Images.Select(s => s.Prediction);
            IPrediction brickPrediction = _predictionService.CalculateBrickPrediction(imagePredictions);
            brick.SetBrickPrediction(brickPrediction);
        }

        private async Task GetAndSaveImagePredictions(IBrick brick)
        {
            foreach (IImage image in brick.Images)
            {
                IPrediction prediction = await _predictionService.GetPrediction(image);
                if (prediction.IsValid())
                    image.SetImagePrediction(prediction);
            }
        }

        public void SavePushResult(IPushResult pushResult)
        {
            _brickRepository.SavePushResult(pushResult);
        }
    }
}
