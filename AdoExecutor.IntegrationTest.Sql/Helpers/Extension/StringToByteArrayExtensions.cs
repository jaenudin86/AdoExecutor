using System;

namespace AdoExecutor.IntegrationTest.Sql.Helpers.Extension
{
  public static class StringToByteArrayExtensions
  {
    public static byte[] ToByteArray(this string hex)
    {
      var numberChars = hex.Length;
      var bytes = new byte[numberChars/2];
      for (var i = 0; i < numberChars; i += 2)
        bytes[i/2] = Convert.ToByte(hex.Substring(i, 2), 16);

      return bytes;
    }
  }
}