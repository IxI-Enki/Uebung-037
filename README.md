# Uebung-037  --  FindAllBits

###### [Angabezettel (.pdf)](https://github.com/IxI-Enki/Uebung-037/blob/main/FindAllBits.pdf)

## Lernziele:  
 - Vertiefung Schleifen  
   
## Aufgabenstellung:  

 **Das Programm „FindAllBits.cs“ soll:**  
 - für mindestens eine gegebene Zahl > 0 vom Typ uint eine Binärumwandlung durchführen.
    > *uint : ein vorzeichenloser Datentyp für ganze positive Zahlen zwischen 0 und UInt32.MaxValue*
 - und das Ergebnis wie im folgenden Beispiel dargestellt ausgeben.  
 
## Beispielausgabe:  

  ![Beispiel](https://github.com/IxI-Enki/Uebung-037/assets/138018029/0e779913-4daa-4784-9edb-46df66a91bad)

### Rechenvorschrift für die Binärumwandlung:  
- Teile die Dezimalzahl solange durch 2, bis sie 0 ist.  
- Die Anzahl der möglichen Divisionen ergibt die Anzahl der Binärstellen.  
  - ***Beispiel:***  
    **Die Dezimalzahl** **6** **entspricht der Binärzahl** **110**: *das sind* **3 Binärstellen**, weil* **6** *insgesamt* **3 Mal** *durch* **2 teilbar** *ist.*  
    > - 6 : 2 = 3, Rest **0**  
    > - 3 : 2 = 1, Rest **1**  
    > - 1 : 2 = 0, Rest **1**

- Bei jeder dieser Divisionen durch 2 ergibt der Rest der Division den binären Bitwert „0“ oder „1“ der gesuchten Binärzahl von rechts nach links gelesen.  
  > *beginnend also rechts mit dem Bitwert für die niedrigste Binärstelle*  

---

# **SPOILER**  

### Ausgabe: 
![ausgabe](https://github.com/IxI-Enki/Uebung-037/assets/138018029/7c4167e9-7f69-4ef5-b51d-acd9660ac417)


> [!TIP]
>
> *[C#] Visual Studio :*

 ```c#
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

```


