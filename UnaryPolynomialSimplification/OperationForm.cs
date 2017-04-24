using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnaryPolynomialSimplification
{
    public partial class OperationForm : Form
    {
        public OperationForm()
        {
            InitializeComponent();
        }

        private void simplifyButton_Click(object sender, EventArgs e)
        {
            string initialFormula = initialFormulaTextBox.Text;

            //string monoidalRegularString = @"[a-zA-Z]{2}";
            //string[] monoidals = initialFormula.Split(new char[2] { '+', '-' });
            //string monoidalsString = "";
            //for (int i = 0; i < monoidals.Length; i++)
            //{
            //    monoidalsString += monoidals[i]+",";
            //}

            int[] symbolIndex = findCharsIndex(new char[2] { '+', '-' }, initialFormula);
            string[] monoidals = useSymbolPositionSplit(symbolIndex, initialFormula);
            List<NameList<string>> classifyMonoidalsList = classifyMonoidalsByPow(monoidals);
            string monoidalsString = "";
            //for (int i = 0; i < symbolIndex.Length; i++)
            //{
            //    monoidalsString += symbolIndex[i] + ",";
            //}
            //for (int i = 0; i < monoidals.Length; i++)
            //{
            //    monoidalsString += monoidals[i]+",";
            //}
            for (int i = 0; i < classifyMonoidalsList.Count; i++)
            {
                //monoidalsString += monoidals[i]+",";
                for (int j = 0; j < classifyMonoidalsList[i].Count; j++)
                {
                    monoidalsString += classifyMonoidalsList[i][j] + ",";
                }
            }

            DialogResult dr1 = MessageBox.Show(monoidalsString, "result");
        }

        private List<NameList<string>> classifyMonoidalsByPow(string[] monoidals)
        {
            //NameList<string> 
            Regex regex = new Regex(@"[\^]\d");
            List<NameList<string>> list = new List<NameList<string>>();

            //string str5 = "sdfg";
            //bool result1 = Regex.IsMatch(str1, @"(^[+-]?\d*[.]?\d*$)|\s*");

            for (int i = 0; i < monoidals.Length; i++)
            {
                string currentMonoidal = monoidals[i];

                bool isPowMonoidal = Regex.IsMatch(currentMonoidal, @"[\^]\d");
                if (isPowMonoidal)
                {
                    MatchCollection mc = regex.Matches(currentMonoidal);
                    string name = mc[0].Value;

                    bool nameExist = false;
                    for (int j = 0; j < list.Count; j++)
                    {
                        NameList<string> currentList = list[j];
                        if (currentList.name.Equals(name))
                        {
                            nameExist = true;
                            currentList.Add(currentMonoidal);
                            break;
                        }
                    }
                    if (!nameExist)
                    {
                        NameList<string> nameList = new NameList<string>();
                        nameList.name = name;
                        nameList.Add(currentMonoidal);
                        list.Add(nameList);
                    }
                }
                else
                {
                    bool constantMonoidalExist = false;
                    for (int j = 0; j < list.Count; j++)
                    {
                        NameList<string> currentList = list[j];
                        if (currentList.name.Equals(""))
                        {
                            constantMonoidalExist = true;
                            currentList.Add(currentMonoidal);
                            break;
                        }
                    }
                    if (!constantMonoidalExist)
                    {
                        NameList<string> nameList = new NameList<string>();
                        nameList.name = "";
                        nameList.Add(currentMonoidal);
                        list.Add(nameList);
                    }
                }
            }

            return list;
        }

        private string[] useSymbolPositionSplit(int[] symbolIndex, string initialFormula)
        {
            string[] monoidals = new string[symbolIndex.Length+1];
            int startPosition = 0;
            for (int i = 0; i < monoidals.Length; i++)
            {
                if(i == 0){
                    startPosition = 0;
                }
                else
                {
                    startPosition = symbolIndex[i-1];
                }

                if (i < monoidals.Length-1)
                {
                    monoidals[i] = initialFormula.Substring(startPosition, symbolIndex[i] - startPosition);
                }
                else//i == monoidals.Length-1
                {
                    monoidals[i] = initialFormula.Substring(startPosition, initialFormula.Length - startPosition);
                }

                
            }

            return monoidals;
        }

        private int[] findCharsIndex(char[] chars, string target)
        {
            List<List<int>> allIndexs = new List<List<int>>();
            char[] targetCharArray = target.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                List<int> indexs = new List<int>();
                char c = chars[i];

                for (int j = 0; j < targetCharArray.Length; j++)
                {
                    if (c == targetCharArray[j])
                    {
                        indexs.Add(j);
                    }
                }

                allIndexs.Add(indexs);
            }

            return convertTwoDimensionIntListToOrderOneDimension(allIndexs);
        }

        private int[] convertTwoDimensionIntListToOrderOneDimension(List<List<int>> indexs){
            int arrayLengh = 0;
            for (int i = 0; i < indexs.Count; i++)
            {
                arrayLengh += indexs[i].Count;
            }

            int[] oneDimensionIndexs = new int[arrayLengh];

            int cursor = 0;
            for (int i = 0; i < indexs.Count; i++)
            {
                for (int j = 0; j < indexs[i].Count; j++)
                {
                    oneDimensionIndexs[cursor] = indexs[i][j];
                    cursor++;
                }
            }

            Array.Sort(oneDimensionIndexs);
            return oneDimensionIndexs;
        }
    }
}
