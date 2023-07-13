using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class AliBabaAndNHouses
    {
        static int[] extract_arr;
        public static int SolveValue(int[] values, int N)
        {
            int[] extra_arr = new int[N];
            extract_arr = new int[N];

            if (N < 0)
                return 0;
            else if (N == 0)
            {
                extract_arr[0] = 1;
                return values[0];
            }

            else if (N == 2)
            {
                extract_arr[1] = 1;
                return Math.Max(values[0], values[1]);
            }

            extra_arr[0] = values[0];
            extract_arr[0] = 1;

            if (values[0] > values[1])
            {
                extract_arr[0] = 1;
                extra_arr[1] = values[0];

            }
            else
            {
                extract_arr[1] = 1;
                extra_arr[1] = values[1];
            }

            for (int i = 2; i < N; i++)
            {
                int max_amount_0f_money_R = values[i] + extra_arr[i - 2]; // maxAmountOfMoneyIfHouseRobbed 
                int max_amount_0f_money_NR = extra_arr[i - 1]; // maxAmountOfMoneyIfHouseNotRobbed 

                if (max_amount_0f_money_R > max_amount_0f_money_NR)
                {
                    extra_arr[i] = max_amount_0f_money_R;
                    extract_arr[i] = 1;
                }
                else
                {
                    extra_arr[i] = max_amount_0f_money_NR;
                    extract_arr[i] = 0;

                }

            }
            return extra_arr[N - 1];
        }


        public static int[] ConstructSolution(int[] values, int N)
        {
            int[] solution = new int[N];
            int j = 0;
            int i = N - 1;

            while (i >= 0)
            {
                if (extract_arr[i] == 1)
                {
                    solution[j] = i + 1;
                    j++;
                    i -= 2;
                }
                else
                    i--;

            }

            Array.Resize(ref solution, j);
            Array.Reverse(solution);
            return solution;
        }
    }
}
