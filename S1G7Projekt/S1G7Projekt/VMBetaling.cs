using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class VMBetaling
    {
        public int VoksenPris = 100;    // Voksen betaler 100%
        public int Barn715 = 50;        // Barn 7-15 betaler 50%
        public int Barn36 = 25;         // Barn 3-6 betaler 25%
        public int BarnU3 = 0;          // Barn u. 3 betaler 0%



        public string SelectedHusNr { get; set; }
        public List<String> HusNr { get; set; }
        public int[,] BetalingsArray;
        public int[,] BetalingsArrayPrHus;

        public double BetalingMan { get; set; }
        public double BetalingTir { get; set; }
        public double BetalingOns { get; set; }
        public double BetalingTor { get; set; }


        public double ChefBetalingMan { get; set; }
        public double ChefBetalingTir { get; set; }
        public double ChefBetalingOne { get; set; }
        public double ChefBetalingTor { get; set; }




        public VMBetaling()
        {
            double[] LoadedChefBetalingsArray = FileHandler.LoadChefBetaling();

            ChefBetalingMan = LoadedChefBetalingsArray[0];
            ChefBetalingTir = LoadedChefBetalingsArray[1];
            ChefBetalingOne = LoadedChefBetalingsArray[2];
            ChefBetalingTor = LoadedChefBetalingsArray[3];
        }


        public void GemChefBetaling()
        {
            double[] ChefBetalingsArray = new double[4];
            FileHandler.SaveChefBetaling(ChefBetalingsArray);
        }


        public void UdregnBetaling()
        {

            Dictionary<String, List<String>> TempLoad = FileHandler.LoadTilmeldingJsonAsync();
            int i = 0;
            BetalingsArray = new int[TempLoad.Count, 4];
            foreach (KeyValuePair<string, List<string>> pair in TempLoad)
            {
                    BetalingsArray[i, 0] = int.Parse(pair.Value[1]);
                    BetalingsArray[i, 1] = int.Parse(pair.Value[2]);
                    BetalingsArray[i, 2] = int.Parse(pair.Value[3]);
                    BetalingsArray[i, 3] = int.Parse(pair.Value[4]);
                
                i++;
            }

            double TotalDiv = 0;
            for (int j = 0; j < BetalingsArray.Length; j++)
            {
                TotalDiv = TotalDiv + ((BetalingsArray[j, 0]*VoksenPris) + (BetalingsArray[j, 1]*Barn715) + (BetalingsArray[j, 2]*Barn36) + (BetalingsArray[j, 3]*BarnU3));
            }


            double TotalChefBetaling = (ChefBetalingMan + ChefBetalingTir + ChefBetalingOne + ChefBetalingTor);

            double BetalingPrPerson = TotalChefBetaling/TotalDiv;


            int k = 0;
            foreach (KeyValuePair<string, List<string>> pair in TempLoad)
            {
                if (pair.Key == SelectedHusNr)
                {
                    BetalingsArrayPrHus[k, 0] = (int.Parse(pair.Value[1])+ int.Parse(pair.Value[2])+ int.Parse(pair.Value[3])+ int.Parse(pair.Value[4]));
                    k++;
                }
            }

            BetalingMan = BetalingsArrayPrHus[0, 0] * BetalingPrPerson;
            BetalingTir = BetalingsArrayPrHus[1, 0] * BetalingPrPerson;
            BetalingOns = BetalingsArrayPrHus[2, 0] * BetalingPrPerson;
            BetalingTor = BetalingsArrayPrHus[3, 0] * BetalingPrPerson;
        }
    }
}
