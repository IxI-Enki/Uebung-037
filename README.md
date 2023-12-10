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

> [!TIP]
>
  > *<details><summary>[C#] Visual Studio : </summary>*
  >
  > ```c#
  >
  >
  > ```
  >
  > </details>
>
