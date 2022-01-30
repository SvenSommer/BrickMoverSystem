using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xunit;

namespace BrickHandler.Model.Tests
{
    public class BrickTests
    {
        [Fact]
        public void CreateBrick()
        {
            IEnumerable<IImage> images = GetTestImages(1);
            Brick brick = new Brick(1, images, new List<ITimeAndPosition>());

            Assert.Equal(1, brick.Id);
            Assert.Single(brick.Images);
            Assert.Empty(brick.Sightings);
        }

        [Fact]
        public void CreateBrickWithTimeAndPositions()
        {
            IEnumerable<IImage> images = GetTestImages(1);
            IEnumerable<ITimeAndPosition> timeAndPositions = GetTestSightings(1);
            Brick brick = new Brick(1, images, new List<ITimeAndPosition>());

            Assert.Equal(1, brick.Id);
            Assert.Single(brick.Images);
            Assert.Empty(brick.Sightings);
        }




        [Fact]
        public void SetBrickPrediction()
        {
            Brick brick = GetTestBrick(6);
            brick.Images.First().Prediction = GetTestPrediction(0.9, 0.9);

            brick.SetBrickPrediction(new Prediction(new ColorPrediction(1, 0.9), new PartNoPrediction("Partno", 0.8)));
            
            Assert.Equal(1, (int)brick.Prediction.Color.Id);
            Assert.Equal("Partno", (string)brick.Prediction.Part.No);
            Assert.Equal(0.9, brick.Prediction.Color.Confidence);
            Assert.Equal(0.8, brick.Prediction.Part.Confidence);
        }



        private Brick GetTestBrick(int imagesCount)
        {
            IEnumerable<IImage> images = GetTestImages(imagesCount);
            return new Brick(1, images, new List<ITimeAndPosition>());
        }

        private static IEnumerable<IImage> GetTestImages(int imagesCount)
        {
            List<Image> images = new List<Image>();
            for (int i = 0; i < imagesCount; i++)
            {
                images.Add(new Image(i, "", CameraPosition.BottomCenter, Camera.Brio));
            }
            return images;
        }

        private IEnumerable<ITimeAndPosition> GetTestSightings(int numberOfEntities)
        {
            List<ITimeAndPosition> sightings = new List<ITimeAndPosition>();
            for (int j = 0; j < numberOfEntities; j++)
            {
                sightings.Add(new TimeAndPosition(new DateTime(2022,01,01,11,01,22), new Point(23,32)));
            }

            return sightings;
        }

        private Prediction GetTestPrediction(double colorConfidence, double partNoConfidence)
        {
            return new Prediction(new ColorPrediction(1, colorConfidence), new PartNoPrediction("", partNoConfidence));
        }


    }
}
