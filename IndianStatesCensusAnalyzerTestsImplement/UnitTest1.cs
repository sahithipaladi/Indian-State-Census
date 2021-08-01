using NUnit.Framework;
using IndianStatesCensusAnalyzer;
using IndianStatesCensusAnalyzer.DTO;
using System.Collections.Generic;
using System;

namespace IndianStatesCensusAnalyzerTests
{
    public class Tests
    {
        //State Census Header
        string stateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        // CSV File paths
        string stateCensusPath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndiaStateCensusData.csv";
        string wrongCensusPath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndiaStateData.csv";
        string wrongTypeStateCensusPath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndiaStateCensusData.txt";
        string wrongHeaderStateCensusPath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\WrongIndiaStateCensusData.csv";
        string delimiterStateCensusPath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\DelimiterStateCensusData.csv";
        IndianStatesCensusAnalyzer.CSVAdapterFactory csv;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;
        [SetUp]
        public void Setup()
        {
            csv = new IndianStatesCensusAnalyzer.CSVAdapterFactory();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }
        //---------------------------------------UC 1 : TC 1.1-------------------------------------------
        //Given the States Census CSV file, Check to ensure the Number of Records matches
        [Test]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(IndianStatesCensusAnalyzer.CensusAnalyser.Country.INDIA, stateCensusPath, stateCensusHeaders);
            Assert.AreEqual(29, stateRecords.Count);

        }
        //---------------------------------------UC 1 : TC 1.2-------------------------------------------
        //Given the States Census CSV file, if incorrect return a custom exception
        [Test]
        public void GivenIncorrectFileShouldReturnCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, stateCensusHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //---------------------------------------UC 1 : TC 1.3-------------------------------------------
        //Given the States Census CSV file when correct but type incorrect returns custom exception
        [Test]
        public void GivenWrongTypeShouldReturnCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCensusPath, stateCensusHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //---------------------------------------UC 1 : TC 1.4-------------------------------------------
        //Given the States Census CSV file when correct but delimiter incorrect returns custom exception
        [Test]
        public void GivenWrongDelimiterShouldReturnCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, stateCensusHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //---------------------------------------UC 1 : TC 1.5-------------------------------------------
        //Given the States Census CSV file when correct but csv header incorrect returns custom exception
        [Test]
        public void GivenWrongHeaderShouldReturnCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, stateCensusHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
