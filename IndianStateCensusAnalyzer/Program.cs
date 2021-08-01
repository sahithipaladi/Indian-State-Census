using IndianStatesCensusAnalyzer.DTO;
using System;
using System.Collections.Generic;
using static IndianStatesCensusAnalyzer.CensusAnalyser;

namespace IndianStatesCensusAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------Indian State Census Analyser---------------------");
            string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
            string stateCensusPath = @"D:\tvstraining\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\CSVFiles\IndiaStateCensusData.csv";
            string stateCodePath = @"D:\tvstraining\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\CSVFiles\IndiaStateCode.csv";

            CensusAnalyser censusAnalyser;
            Dictionary<string, CensusDTO> totalRecords;
            Dictionary<string, CensusDTO> stateRecords;
            censusAnalyser = new CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();

            totalRecords = censusAnalyser.LoadCensusData(Country.INDIA, stateCodePath, indianStateCodeHeaders);
            stateRecords = censusAnalyser.LoadCensusData(Country.INDIA, stateCensusPath, indianStateCensusHeaders);
            Console.WriteLine(totalRecords.Count);
            Console.WriteLine(stateRecords.Count);
        }
    }
}