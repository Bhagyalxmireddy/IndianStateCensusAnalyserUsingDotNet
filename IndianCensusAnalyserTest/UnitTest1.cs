using NUnit.Framework;
using IndiaStateCensusAnalyser;
using IndiaStateCensusAnalyser.POCO;
using static IndiaStateCensusAnalyser.CensusAnalyser;
using System.Collections.Generic;

namespace IndianCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\USER\source\repos\IndiaStateCensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\USER\source\repos\IndiaStateCensusAnalyser\IndianCensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData (1).csv";
        static string delimeterIndianCensusFilePath = @"C:\Users\USER\source\repos\IndiaStateCensusAnalyser\IndianCensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\USER\source\repos\IndiaStateCensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\USER\source\repos\IndiaStateCensusAnalyser\IndianCensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";
        static string delimeterIndianStateCodeFilepath = @"C:\Users\USER\source\repos\IndiaStateCensusAnalyser\IndianCensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongIndiaCensusFileFilePath = @"C:\Users\USER\source\repos\IndiaStateCensusAnalyser\IndianCensusAnalyserTest\CSVFiles\IndianStateCensus.txt";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;
        
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();

        }

        [Test]
        public void givenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecords.Count);           
        }
        [Test]
        public void givenWrongIndianCensusDataFile_WhenReaded_ShouldThroughCustomExcpection()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaCensusFileFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            /* var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
             Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);*/
        }
        [Test]
        public void givenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaCensusFileFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void givenWrongDelimiterIndianCensusFile_WhenReaded_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void givenWrongHeaderFileIndianCensusFile_WhenReaded_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void givenIndianStateCodeFile_WhenReaded_ShoulReturnException()
        {
            stateRecords = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodHeaders);
            Assert.AreEqual(37, stateRecords.Count);
        }
        [Test]
        public void givenWrongIndianStateCodeFile_WhenReaded_ShouldThrowException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() =>
                                    censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCodHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldThrowException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() =>
                                    censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaCensusFileFilePath, indianStateCodHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenWrongDelimiterIndianStateCodeFile_WhenReaded_ShouldThrowException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() =>
                                    censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilepath, indianStateCodHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenWrongHeaderIndianStateCodeFile_WhenReaded_ShouldThrowException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() =>
                                    censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCodHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}