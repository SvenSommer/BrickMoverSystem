using System;
using System.Text;
using BrickHandler.RabbitMQAdapter.Extensions;
using Xunit;

namespace BrickHandler.RabbitMQAdapter.Tests
{
    public class EncodingTests
    {
        [Fact]
        public void ConvertStringToByteArray()
        {
            const string phrase = "TestPhrase";
            Assert.Equal(Encoding.UTF8.GetBytes(phrase), phrase.ToByteArray());
        }

        [Fact]
        public void ConvertBytesToString()
        {
            const string phrase = "TestPhrase";
            byte[] bytes = Encoding.UTF8.GetBytes(phrase);
            Assert.Equal(phrase, bytes.GetPayloadString());
        }
    }
}
