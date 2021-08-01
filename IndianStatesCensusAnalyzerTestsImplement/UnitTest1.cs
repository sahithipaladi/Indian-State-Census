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


        //State Code Header
        string stateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        // CSV File paths
        string stateCodePath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndiaStateCode.csv";
        string wrongCodePath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles.csv";
        string wrongTypeStateCodePath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndiaStateCode.txt";
        string wrongHeaderStateCodePath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\WrongIndiaStateCode.csv";
        string delimiterStateCodePath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\DelimiterStateCode.csv";

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
        public void GivenIncorrectFileForStateCensusShouldReturnCustomException()
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
        public void GivenWrongTypeForStateCensusShouldReturnCustomException()
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
        public void GivenWrongDelimiterForStateCensusShouldReturnCustomException()
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
        public void GivenWrongHeaderForStateCensusShouldReturnCustomException()
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

        //---------------------------------------UC 2 : TC 2.1-------------------------------------------
        //Given the States Census CSV file, Check to ensure the Number of Records matches
        [Test]
        public void GivenStateCodeCSVShouldReturnRecords()
        {
            totalRecords = csv.LoadCsvData(IndianStatesCensusAnalyzer.CensusAnalyser.Country.INDIA, stateCodePath, stateCodeHeaders);
            Assert.AreEqual(37, totalRecords.Count);

        }
        //---------------------------------------UC 2 : TC 2.2-------------------------------------------
        //Given the States Census CSV file, if incorrect return a custom exception
        [Test]
        public void GivenIncorrectFileForStateCodeShouldReturnCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCodePath, stateCodeHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //---------------------------------------UC 2 : TC 2.3-------------------------------------------
        //Given the States Census CSV file when correct but type incorrect returns custom exception
        [Test]
        public void GivenWrongTypeForStateCodeShouldReturnCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, stateCodeHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //---------------------------------------UC 2 : TC 2.4-------------------------------------------
        //Given the States Census CSV file when correct but delimiter incorrect returns custom exception
        [Test]
        public void GivenWrongDelimiterForStateCodeShouldReturnCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCodePath, stateCodeHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //---------------------------------------UC 2 : TC 2.5-------------------------------------------
        //Given the States Census CSV file when correct but csv header incorrect returns custom exception
        [Test]
        public void GivenWrongHeaderForStateCodeShouldReturnCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodePath, stateCodeHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}