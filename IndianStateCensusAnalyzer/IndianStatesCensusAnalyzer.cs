using IndianStatesCensusAnalyzer.DataDAO;
using IndianStatesCensusAnalyzer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyzer
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> datamap;

        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            try
            {
                datamap = new Dictionary<string, CensusDTO>();
                censusData = GetCensusData(csvFilePath, dataHeaders);
                foreach (string data in censusData.Skip(1))
                {
                    //Checking the delimiter
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                    }
                    string[] coloumn = data.Split(',');
                    //Checking the csv files
                    if (csvFilePath.Contains("IndiaStateCode.csv"))
                        datamap.Add(coloumn[1], new CensusDTO(new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                    if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                        datamap.Add(coloumn[1], new CensusDTO(new CensusDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));

                }
                return datamap;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}