using Moq;
using ProgrammingExercise.Features.AlgoLand.v2;
using ProgrammingExercise.Features.AlgoLand.v3;
using ProgrammingExercise.Models.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.v3
{
    public class AlgoRunnerServiceV3Should
    {
        private readonly Mock<ITimeProviderService> _timeProviderServiceMock;
        private readonly Mock<IPigLatinService> _pigLatinServiceMock;
        private readonly Mock<IPalindromeService> _palindromeServiceMock;

        private readonly IAlgoRunnerServiceV3 _algoRunnerServiceV3;

        private readonly string _defaultError = "adsadassdERRORR";
        private readonly string _defaultPigLatinResult = "igpay atin";
        public AlgoRunnerServiceV3Should()
        {
            _timeProviderServiceMock = new Mock<ITimeProviderService>();
            _pigLatinServiceMock = new Mock<IPigLatinService>();
            _palindromeServiceMock = new Mock<IPalindromeService>();

            SetupTimeProviderServiceMock(new DateTime(DateTime.Now.Year, 1, 1, 1, 1, 7), isValid: true);
            SetupPigLatinServiceMock(_defaultPigLatinResult);
            SetupPalindromeServiceMock();

            _algoRunnerServiceV3 = new AlgoRunnerServiceV3(_timeProviderServiceMock.Object, _pigLatinServiceMock.Object, _palindromeServiceMock.Object);

        }

        private void SetupTimeProviderServiceMock(DateTime? dateTime = null, bool isValid = true)
        {
            var response = new ServiceResponse<DateTime?>();
            if(isValid)
                response.Data = dateTime;

            if (!isValid)
                response.Error = _defaultError;

            _timeProviderServiceMock.Setup(x => x.GetCurrentTime()).ReturnsAsync(response);
        }

        private void SetupPigLatinServiceMock(string pigLatinResult)
        {
            _pigLatinServiceMock.Setup(x => x.ConvertToPigLatin(It.IsAny<string>())).Returns(pigLatinResult);
        }

        private void SetupPalindromeServiceMock(bool isPalindrome = true)
        {
            _palindromeServiceMock.Setup(x => x.IsPalindrome(It.IsAny<string>())).Returns(isPalindrome);
        }

        [Fact]
        public async Task ReturnError_WhenTimeProviderServiceReturnsError()
        {
            SetupTimeProviderServiceMock(isValid: false);

            var response = await _algoRunnerServiceV3.GetResult();

            Assert.NotNull(response);
            Assert.Null(response.Data);
            Assert.Equal(_defaultError, response.Error);
        }

        [Fact]
        public async Task ReturnPigLatinResultWhenSecondIsEven()
        {
            // arrange
            SetupTimeProviderServiceMock(new DateTime(DateTime.Now.Year, 1, 1, 1, 1, 8), isValid: true);

            // act
            var response = await _algoRunnerServiceV3.GetResult();

            // assert
            Assert.NotNull(response);
            Assert.Equal(_defaultPigLatinResult, response.Data);
        }


    }
}
