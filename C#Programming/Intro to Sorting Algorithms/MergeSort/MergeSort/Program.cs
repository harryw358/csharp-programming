using System.Reflection;

namespace MergeSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] newItems = new int[8] { 43, 1, 65, 32, 76, 23, 852, 54 };
            List<int> newItemsList = new List<int>();

            int[] items = new int[100];
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                items[i] = rnd.Next(0, 101);
                newItemsList.Add(rnd.Next(0, 101));
            }

            MergeSort(newItemsList);

            foreach(int num in newItemsList)
            {
                Console.WriteLine(num);
            }

            Console.ReadKey();
        }

        static void mergeSort(int[] mergeList)
        {
            if (mergeList.Length > 1)
            {
                int middle = mergeList.Length / 2; // index for middle of array
                int pointer = 0, pointerFill = 0;
                int[] leftItems = new int[mergeList.Length / 2];
                int[] rightItems = new int[mergeList.Length / 2 + (mergeList.Length % 2)];

                // fills the left array
                do
                {
                    leftItems[pointer] = mergeList[pointer];
                    pointer++;
                }
                while (pointer != middle);

                // fills the right array
                do
                {
                    rightItems[pointerFill] = mergeList[pointer];
                    pointer++;
                    pointerFill++;
                }
                while (pointer != mergeList.Length);

                mergeSort(leftItems);
                mergeSort(rightItems);

                int i = 0, j = 0, k = 0;

                while (i < leftItems.Length && j < rightItems.Length)
                {
                    if (leftItems[i] < rightItems[j])
                    {
                        mergeList[k] = leftItems[i];
                        i++;
                    }
                    else
                    {
                        mergeList[k] = rightItems[j];
                        j++;
                    }
                    k++;
                }

                // check if left half has elements not merged
                while (i < leftItems.Length)
                {
                    mergeList[k] = leftItems[i]; // if so, add to merge list
                    i++;
                    k++;
                }

                // check if right half has elements not merged
                while (j < rightItems.Length)
                {
                    mergeList[k] = rightItems[j]; // if so, add to merge list
                    j++;
                    k++;
                }
            }
        }
        private static void MergeSort(List<int> mergeList)
        {
            if (mergeList.Count > 1)
            {
                //int mid = mergeList.Count / 2;
                //List<int> leftHalf = FillHalf("left", mid, mergeList);
                //List<int> rightHalf = FillHalf("right", mid, mergeList);

                //MergeSort(leftHalf);
                //MergeSort(rightHalf);

                int middle = mergeList.Count / 2; // index for middle of array
                int pointer = 0, pointerFill = 0;
                List<int> leftHalf = new List<int>();
                List<int> rightHalf = new List<int>();

                // fills the left array
                do
                {
                    leftHalf.Add(mergeList[pointer]);
                    pointer++;
                }
                while (pointer != middle);

                // fills the right array
                do
                {
                    rightHalf.Add(mergeList[pointer]);
                    pointer++;
                    pointerFill++;
                }
                while (pointer != mergeList.Count);

                MergeSort(leftHalf);
                MergeSort(rightHalf);

                int i = 0, j = 0, k = 0;

                while (i < leftHalf.Count && j < rightHalf.Count)
                {
                    if (leftHalf[i] < rightHalf[j])
                    {
                        mergeList[k] = leftHalf[i];
                        i++;
                    }
                    else
                    {
                        mergeList[k] = rightHalf[j];
                        j++;
                    }
                    k++;
                }

                // check if the left half has elements not merged
                while (i < leftHalf.Count)
                {
                    mergeList[k] = leftHalf[i];
                    i++;
                    k++;
                }

                // check if left half has elements not merged
                while (j < rightHalf.Count)
                {
                    mergeList[k] = rightHalf[j];
                    j++;
                    k++;
                }
            }
            else
            {
                return;
            }
        }
        private static List<int> FillHalf(string side, int mid, List<int> list)
        {
            List<int> half = new List<int>();

            switch (side)
            {
                case "left":
                    {
                        for (int i = 0; i <= 0; i++)
                        {
                            half.Add(list[i]);
                        }
                    }
                    break;
                case "right":
                    {
                        for (int i = mid + 1; i <= list.Count - 1; i++)
                        {
                            half.Add(list[i]);
                        }
                    }
                    break;
            }

            return half;
        }
    }
}