using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace BUDTechnicalTest
{
    public class WorldBankCountryAPI
    {
        public static void Main()
        {
            var worldBank = new WorldBankCountryAPI();

            List<string> allISOCodes;
            allISOCodes = worldBank.ConstructISOList();

            Console.WriteLine("Welcome to the World Bank Country Search");
            Console.WriteLine("Please enter a valid ISO Code Below");
            while (worldBank.InputCheck(allISOCodes, null) == false)
            {
                Console.WriteLine("Invalid ISO code please try again");
            }
            Console.WriteLine("Press enter to close");
            Console.ReadLine();
        }

        public List<string> ConstructISOList()
        {
            List<string> isoCodes = new List<string>();
            XmlReader allCountryReader = XmlReader.Create("https://api.worldbank.org/v2/country?per_page=304");
            while (allCountryReader.Read())
            {
                if (allCountryReader.Name == "wb:country")
                {
                    isoCodes.Add(allCountryReader.GetAttribute("id"));
                }
                else if (allCountryReader.Name == "wb:iso2Code")
                {
                    isoCodes.Add(allCountryReader.ReadInnerXml());
                }
            }
            allCountryReader.Close();
            return isoCodes;
        }

        public bool InputCheck(List<string> _allCodes, string _input)
        {
            string userInput;
            if (_input == null)
            {
                userInput = Convert.ToString(Console.ReadLine());
            }
            else
            {
                userInput = _input;
            }
            if (_allCodes == null) { return false; }

            foreach(string code in _allCodes)
            {
                if(userInput == code)
                {
                    Console.WriteLine("Collecting Data...\n");
                    DisplayXML(userInput);
                    return true;
                }
            }
            return false;
        }

        public bool DisplayXML(string _input)
        {
            if (_input == null)
            {
                Console.WriteLine("Input is null");
                return false;
            }
            XmlReader reader = XmlReader.Create("https://api.worldbank.org/v2/country/" + _input);
            List<string> desiredFields = new List<string>();
            desiredFields.Add("wb:name");
            desiredFields.Add("wb:region");
            desiredFields.Add("wb:capitalCity");
            desiredFields.Add("wb:longitude");
            desiredFields.Add("wb:latitude");

            while(reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && desiredFields.Contains(reader.Name))
                { 
                    Console.WriteLine(reader.ReadInnerXml());                   
                }
            }
            return true;
        }

    }
} 