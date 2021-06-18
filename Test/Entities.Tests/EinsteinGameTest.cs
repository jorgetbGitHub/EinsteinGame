using System;
using Xunit;

namespace Entities.Tests
{
    public class EinsteinGameTest
    {
        [Fact]
        public void EinsteinGame_CheckRules()
        {
            //There
            EinsteinGame einsteinGame = new EinsteinGame();

            //When
            string word1 = einsteinGame.Play(3);
            string word2 = einsteinGame.Play(5);
            string word3 = einsteinGame.Play(15);

            //Then
            Assert.Equal("fizz", word1);
            Assert.Equal("buzz", word2);
            Assert.Equal("fizzbuzz", word3);
        }
    }
}
