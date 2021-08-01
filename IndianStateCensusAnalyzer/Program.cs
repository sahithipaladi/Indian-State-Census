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
            //Initialising headers
            string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
            //CSV File paths
            string stateCensusPath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndiaStateCensusData.csv";
            string stateCodePath = @"C:\Users\sahithi.p\source\repos\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\CSVFiles\IndiaStateCode.csv";

            CensusAnalyser censusAnalyser = new CensusAnalyser();
            Dictionary<string, CensusDTO> totalRecords = new Dictionary<string, CensusDTO>();
            Dictionary<string, CensusDTO> stateRecords = new Dictionary<string, CensusDTO>();

            totalRecords = censusAnalyser.LoadCensusData(Country.INDIA, stateCodePath, indianStateCodeHeaders);
            stateRecords = censusAnalyser.LoadCensusData(Country.INDIA, stateCensusPath, indianStateCensusHeaders);
            Console.WriteLine(totalRecords.Count);
            Console.WriteLine(stateRecords.Count);
        }
    }
}