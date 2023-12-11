/*-----------------------------------------------------------------------------
 *                      HTBLA-Leonding / Class: 3ACIF
 *-----------------------------------------------------------------------------
 *                      Jan Ritt
 *-----------------------------------------------------------------------------
 *  Description:  Decimal to binary calculator
 *-----------------------------------------------------------------------------
*/

/*_________________________________libraries_________________________________*/
using System;                   //  
using System.Text;              //  Unicode Symbols
using System.Threading;         //  Thread.Sleep(1000) = 1 sec

/*---------------------------------- START ----------------------------------*/

namespace FindAllBits       // 
{                           //
  public class Program      // 
  {                         //
    static void Main()      //
    {
      /*------------------------- console_settings --------------------------*/
      const int cWidth = 53;                     //  console width
      const int cHeight = 46;                    //  & height
      Console.SetWindowSize(cWidth, cHeight);    //
      Console.OutputEncoding = Encoding.UTF8;    //  Unicode Symbols

      /*----------------------------- VARIABLES -----------------------------*/
      string userInput;      //  
      int index,
          formattedIndexed;  //  ✏
      double sumBitValue;
      UInt32 unsignedInput,
             savedInput;

      bool[] indexedBinary = new bool[32];
      double[] bitValue = new double[32];

      bool abort;

      /*-------------------------------- HEAD -------------------------------*/
      Console.Clear();
      Console.Write("\n                    Find All Bits                    " +
      /* cWidth: */ "\n=====================================================");

      /*---[in:]-------------------- PROMPT_USER ----------------------------*/
      do
      {
        Console.Write($"\n Geben Sie eine Zahl zwischen 0 und {UInt32.MaxValue} ein." +
                       "\n [0] - zum abbrechen ");
        /*---------------------------- GET_INPUT ----------------------------*/
        userInput = Console.ReadLine();
        UInt32.TryParse(userInput, out unsignedInput);

        abort = (unsignedInput == 0) ? true : false;
        savedInput = unsignedInput;
        /*---[calc:]---------------------------------------------------------*/
        if (abort == false)
        {
          index = 0;        // reset index 
          sumBitValue = 0;  // reset sum

          /* while input can be devided by 2 with a remainder remaining: */
          while (unsignedInput > 0 /* && (unsignedInput % 2 != 0) */ )
          {
            // bool array to safe the 0 or 1 at index:
            indexedBinary[index] = (unsignedInput % 2 != 0) ? true : false;
            formattedIndexed = (indexedBinary[index]) ? 1 : 0;
            // OUT:
            Console.Write($"\n {formattedIndexed} x 2^{index}");

            // if 1 at index:
            if (indexedBinary[index])
            {  // calc: 2 to the power of index → OUT: value
              bitValue[index] = Math.Pow(2, index);
              Console.Write($" = {bitValue[index]}");
            }
            else
            {  // value at index = 0 → OUT: empty line
              bitValue[index] = 0;
            }

            // calc: sum:
            sumBitValue = sumBitValue + bitValue[index];
            // calc: input for next iteration:
            unsignedInput = unsignedInput / 2;
            index++;  // iterate index by 1
          }

          /*---[out:]--------------------- SOLUTION -----------------------------*/
          Console.Write("\n=====================================================" +
                        $"\n Dezimalzahl: {(savedInput.ToString().PadLeft(cWidth - 22))}" +
                        $"\n Summe aller Bitwerte: {(sumBitValue.ToString().PadLeft(cWidth - 31))}" +
                        "\n-----------------------------------------------------");
          // OUT BONUS
          // - reversed output with seperator that cuts leading zeros - eg. 1010 0001 1101
          Console.Write("\n Binär: ");
          index = 31;
          do
          {
            if (!indexedBinary[index])
            {
              index--;
            }
            else
            {
              do
              {
                if ((index + 1) % 4 == 0)
                  Console.Write(" ");
                if (indexedBinary[index])
                {
                  Console.Write("1");
                }
                else
                  Console.Write("0");
                index--;
              } while (index >= 0);
            }
          } while (index >= 0);

          Console.Write("\n=====================================================");
        }
        else
          Console.Write("\n Abbrechen gewählt.");
      } while (!abort);
      /*-------------------------------- END --------------------------------*/
      Console.Write("\n Zum beenden Eingabetaste drücken..");
      Console.ReadLine();    //  wait for [enter]
      Console.Clear();       //
    }
  }
}