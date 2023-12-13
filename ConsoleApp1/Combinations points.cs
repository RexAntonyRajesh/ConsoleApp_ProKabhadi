using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class CombinationsOld
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            List<PlayerDetails> list = new List<PlayerDetails>();
            list = GetPlayerDetails(list);

            //string fixedpalyers = "Naveen Kumar, A Pawar, M Mehender Sharma, A Malik, Sunil, V Bharathwaj";

            string fixedpalyers = "Bharath II, Aman";
            //string fixedpalyers = "S Tanwar,R Sangaroya,S Jaglan,Ankit,F Atrachali";

            int rownum = 0;
            foreach (var sequence in list.Combinations())
            {
                if (sequence.Count() == 3)
                {
                    dt = formTable_Players3(dt, sequence);
                }
            }
            dt = dt.DefaultView.ToTable();
            foreach (DataRow row in dt.Rows)
            {
                rownum++;
                //string combinationValue = rownum.ToString();
                string combinationValue = "";
                foreach (var column in row.ItemArray)
                {
                    try
                    {
                        decimal vall = Convert.ToDecimal(column);
                    }
                    catch (Exception)
                    {
                        combinationValue += " , " + column;
                    }
                    //combinationValue += " , " + column;
                }
                Console.WriteLine(rownum.ToString() + " , " + fixedpalyers + combinationValue);
                if (rownum != 0 && rownum % 5 == 0)
                    Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static List<PlayerDetails> GetPlayerDetails(List<PlayerDetails> playerDetails)
        {
            PlayerDetails player1 = new PlayerDetails();
            player1.Name = "S Nandal";
            player1.Score = 13.5;
            playerDetails.Add(player1);

            PlayerDetails player2 = new PlayerDetails();
            player2.Name = "J Dahia";
            player2.Score = 15;
            playerDetails.Add(player2);

            PlayerDetails player3 = new PlayerDetails();
            player3.Name = "M Khaler";
            player3.Score = 13.5;
            playerDetails.Add(player3);

            PlayerDetails player4 = new PlayerDetails();
            player4.Name = "R Sethpal";
            player4.Score = 12.5;
            playerDetails.Add(player4);

            PlayerDetails player5 = new PlayerDetails();
            player5.Name = "S Singh";
            player5.Score = 13;
            playerDetails.Add(player5);

            PlayerDetails player6 = new PlayerDetails();
            player6.Name = "Vishal";
            player6.Score = 13;
            playerDetails.Add(player6);

            //PlayerDetails player7 = new PlayerDetails();
            //player7.Name = "M Esmaeil-Nabibakhsh";
            //player7.Score = 12;
            //playerDetails.Add(player7);

            //PlayerDetails player8 = new PlayerDetails();
            //player8.Name = "R Gulia";
            //player8.Score = 13;
            //playerDetails.Add(player8);


            return playerDetails;
        }

        private static DataTable formTable_Players4(DataTable dt, IEnumerable<PlayerDetails> sequence)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Player 1");
                dt.Columns.Add("Player 2");
                dt.Columns.Add("Player 3");
                dt.Columns.Add("Player 4");
                dt.Columns.Add("Total");
                dt.DefaultView.Sort = "Total Asc";
            }

            PlayerDetails player1 = sequence.ElementAt(0);
            PlayerDetails player2 = sequence.ElementAt(1);
            PlayerDetails player3 = sequence.ElementAt(2);
            PlayerDetails player4 = sequence.ElementAt(3);
            double total = player1.Score + player2.Score + player3.Score + player4.Score;
            dt.Rows.Add(player1.Name, player2.Name, player3.Name, player4.Name, total);
            return dt;
        }

        private static DataTable formTable_Players3(DataTable dt, IEnumerable<PlayerDetails> sequence)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Player 1");
                dt.Columns.Add("Player 2");
                dt.Columns.Add("Player 3");
                dt.Columns.Add("Total");
                dt.DefaultView.Sort = "Total Asc";
            }

            PlayerDetails player1 = sequence.ElementAt(0);
            PlayerDetails player2 = sequence.ElementAt(1);
            PlayerDetails player3 = sequence.ElementAt(2);
            double total = player1.Score + player2.Score + player3.Score;
            dt.Rows.Add(player1.Name, player2.Name, player3.Name, total);
            return dt;
        }

        private static DataTable formTable_Players2(DataTable dt, IEnumerable<PlayerDetails> sequence)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Player 1");
                dt.Columns.Add("Player 2");
                dt.Columns.Add("Total");
                dt.DefaultView.Sort = "Total Asc";
            }

            PlayerDetails player1 = sequence.ElementAt(0);
            PlayerDetails player2 = sequence.ElementAt(1);
            double total = player1.Score + player2.Score;
            dt.Rows.Add(player1.Name, player2.Name, total);
            return dt;
        }

        private static DataTable formTable_Players1(DataTable dt, IEnumerable<PlayerDetails> sequence)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Player 1");
                dt.Columns.Add("Total");
                dt.DefaultView.Sort = "Total Asc";
            }

            PlayerDetails player1 = sequence.ElementAt(0);
            double total = player1.Score;
            dt.Rows.Add(player1.Name, total);
            return dt;
        }
    }

    public class PlayerDetails
    {
        public string Name { get; set; }

        public double Score { get; set; }
    }
}
