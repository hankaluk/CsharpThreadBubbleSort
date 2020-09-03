using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSort {
    static class ProgramSuspendResume {
        static FormBS pgForm1;
        static FormBS pgForm2;
        static int[] pgFormData1;
        static int[] pgFormData2;
        static bool ready1 = false;
        static bool ready2 = false;
        static bool end1 = false;
        static bool end2 = false;
        static Thread thread1;
        static Thread thread2;
        static int indexA;
        static int indexB;
        //static int[] pgFormData = { 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 80, 90 };
        //static int[] pgFormData = { 45, 50, 55, 60, 65, 70, 80, 90, 10, 15, 20, 25, 30, 35, 40 };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Mainx() {
            //Random random = new Random();
            //int size = 15;
            //int[] data = new int[size];
            //for (int i = 0; i < data.Length; i++) {
            //    data[i] = random.Next(0, 101);
            //}
            //FormBS form = new FormBS(data);
            //form.Show();
            //BubbleSortSimple(data, form);
            //Thread.Sleep(1000);

            Random random = new Random();
            int size = 15;
            int[] data = new int[size];
            for (int i = 0; i < data.Length; i++) {
                data[i] = random.Next(0, 101);
            }
            pgFormData1 = data;
            pgFormData2 = data;

            thread1 = new Thread(BubbleSortSimple2);
            thread2 = new Thread(BubbleSortFinal2);

            pgForm1 = new FormBS(pgFormData1);
            pgForm2 = new FormBS(pgFormData2);
            pgForm1.Show();
            pgForm2.Show();
            //pgForm2.SetDesktopLocation(pgForm1.Right + 1, pgForm1.Top);
            pgForm2.Location = new System.Drawing.Point(pgForm1.Right + 1, pgForm1.Top);

            thread1.Start();
            thread2.Start();
            while ((end1 == false) || (end2 == false)) {
                pgForm1.ShowData(indexA, indexA + 1);
                pgForm2.ShowData(indexB, indexB + 1);
                do {
                    Thread.Sleep(10);
                } while ((ready1 == false) || (ready2 == false));
                if (end1 == false) {
                    thread1.Resume();
                }
                if (end2 == false) {
                    thread2.Resume();
                }
            }
        }

        private static void BubbleSortSimple(int[] data, FormBS form) {
            int temp;
            for (int j = 0; j < data.Length; j++) {
                for (int i = 0; i < data.Length - 1; i++) {
                    if (data[i] > data[i + 1]) {
                        temp = data[i + 1];
                        data[i + 1] = data[i];
                        data[i] = temp;
                    }
                    //form.ShowData();
                }
                Thread.Sleep(200);
            }
        }
        public static void BubbleSortSimple2() {
            int temp;
            for (int j = 0; j < pgFormData1.Length - 1; j++) {
                for (int i = 0; i < pgFormData1.Length - 1; i++) {
                    ready1 = false;
                    if (pgFormData1[i] > pgFormData1[i + 1]) {
                        temp = pgFormData1[i + 1];
                        pgFormData1[i + 1] = pgFormData1[i];
                        pgFormData1[i] = temp;
                    }
                    Thread.Sleep(30);
                    indexA = i;
                    ready1 = true;
                    //pgForm1.ShowData(i, i + 1);

                    thread1.Suspend();
                }
            }
            end1 = true;
        }

        //public static void BubbleSortFinal() {
        //    bool swapOccurred;
        //    int temp;
        //    do {
        //        swapOccurred = false;
        //        for (int i = 0; i < pgFormData.Length - 1; i++) {
        //            if (pgFormData[i] > pgFormData[i + 1]) {
        //                temp = pgFormData[i + 1];
        //                pgFormData[i + 1] = pgFormData[i];
        //                pgFormData[i] = temp;
        //                swapOccurred = true;
        //            }
        //            pgForm.ShowData(i, i + 1);
        //            Thread.Sleep(100);
        //        }
        //    } while (swapOccurred);
        //    pgForm.ShowData(-2, -2); //na konci jsou všechny prgBary zase zelené :D
        //    Thread.Sleep(500);
        //}

        public static void BubbleSortFinal2() {
            int temp;
            int lastSwapIndex = pgFormData2.Length;
            int currentSwapIndex;
            //end2 = false;
            do {
                currentSwapIndex = 0;
                for (int i = 0; i < lastSwapIndex - 1; i++) {
                    ready2 = false;
                    if (pgFormData2[i] > pgFormData2[i + 1]) {
                        temp = pgFormData2[i + 1];
                        pgFormData2[i + 1] = pgFormData2[i];
                        pgFormData2[i] = temp;
                        currentSwapIndex = i + 1;
                    }
                    Thread.Sleep(30);
                    indexB = i;
                    ready2 = true;
                    //pgForm2.ShowData(i, i + 1);
                    //Thread.Sleep(100);
                    thread2.Suspend();
                }
                lastSwapIndex = currentSwapIndex;
            } while (lastSwapIndex > 0);
            end2 = true;
          }
    }
}

