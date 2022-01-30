﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BrickHandler.RabbitMQAdapter.Extensions
{
    public static class StringExtensions
    {
        public static string GetPayloadString(this byte[] byteArray)
        {
            return Encoding.UTF8.GetString(byteArray);
        }
        public static byte[] ToByteArray(this string phrase)
        {
            return Encoding.UTF8.GetBytes(phrase);
        }
    }
}
