using System;
using System.Linq;

namespace TuduManayer.Domain.Test.Todo.Create
{
    public static class StringGenerator
    {
        private static Random random = new Random();
        
        public static string Generate(int numberOfCharacters)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(
                Enumerable
                    .Repeat(chars, numberOfCharacters)
                    .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}