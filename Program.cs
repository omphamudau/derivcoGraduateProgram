using System;
using System.Collections.Generic;
using System.Linq;

class GraduateProgram {
    
static List<int> doReduction(List <int> list){
     List<int> matchCount = new List<int>();
     
    if (list.Count%2!=0){
        for(int i = 0; i<list.Count/2;i++){
            matchCount.Add(list[i]+list[list.Count-i-1]);
        }
        matchCount.Add(list[list.Count/2]);
    }
    else{
       for(int i = 0; i<list.Count/2;i++){
            matchCount.Add(list[i]+list[list.Count-i-1]);
        } 
    }
    return matchCount;
}

static List<int> list (char[] nameA, char[] nameB, char[] match){
    int sum=0;
    List<int> matchCount = new List<int>();
    char[] newArray = new char[nameA.Length + nameB.Length + match.Length];
    
// Copy/merge the three arrays into the target array.
    Array.Copy(nameA, 0, newArray, 0, nameA.Length);
    Array.Copy(match, 0, newArray, nameA.Length, match.Length);
    Array.Copy(nameB, 0, newArray, (nameA.Length + match.Length), nameB.Length);
 
 for(int j=0; j < newArray.Length; j++){
    if (newArray[j]!='#'){
     sum = sum + 1;
    }
    for (int i =(j+1);i < newArray.Length; i++){
        
      if (newArray[i]==newArray[j] && newArray[i]!='#'){
          newArray[i] = '#';
          sum += 1; 
      }
    }
       if (sum >0 && sum <10){
        matchCount.Add(sum);}
        else if (sum >=10){
           int a= sum/10;
           int b= sum%10;
           matchCount.Add(a); 
           matchCount.Add(b);
        }
        sum =0;
    }
    return matchCount;
  }    

 static int getPercentage(List<int> percentage){  
    bool checkPercentage = false;
    while(!checkPercentage){
        List<int> newP = new List<int> (percentage);
        percentage.Clear();
        percentage = doReduction(newP);
        newP.Clear();  
        if ((percentage.Count==2) &&  percentage[0]<10 && percentage[1]<10){
           checkPercentage = true;
        }
        else{
          int sum =0;
          for(int i=0; i<percentage.Count; i++){
            if (percentage[i]>=10){sum = sum +2;}
            else{sum=sum+1;}
          }
        for(int i=0; i<sum; i++){
           if (percentage[i]>=10){
             int x = percentage[i];
             percentage.RemoveAt(i);
             percentage.Insert(i, (x / 10) );
             percentage.Insert(i+1, (x % 10)); 
             }}}
    }
   
         return ( Convert.ToInt32(string.Format("{0}{1}",percentage[0],percentage[1])));
    
    }

static bool IsAlphabets(string nameA)
{
      if (string.IsNullOrEmpty(nameA) )
          return false;

      for (int i = 0; i < nameA.Length; i++){
          if (!char.IsLetter(nameA[i]))
              return false;
              }
      return true;
}

public static List<string> getFemales(string filePath){
   
   List<string>list= new List<string>();
  
      string[] lines = System.IO.File.ReadAllLines(@filePath);
      for (int i=0; i<lines.Length;i++){
        string[] fields = lines[i].Split(",");
        
         if (fields[1] == "f" || fields[1] == "F"){
             list.Add(fields[0]);
          }
      }   
   return list;
}
public static List<string> getMales(string filePath){
   
   List<string>list= new List<string>();
  
      string[] lines = System.IO.File.ReadAllLines(@filePath);
      for (int i=0; i<lines.Length;i++){
        string[] fields = lines[i].Split(",");
        
         if (fields[1] == "m" || fields[1] == "M"){
             list.Add(fields[0]);
          }
      }   
   return list;
}
 static void SwapInts(List<int> array, int position1, int position2){
        int temp = array[position1]; 
        array[position1] = array[position2];
        array[position2] = temp; 
    }
public static void swapString(List<string> array, int position1, int position2){
        string temp = array[position1]; 
        array[position1] = array[position2]; 
        array[position2] = temp; 
}
 private static void deleteFemalesDuplicates(List<string> femalesList)
    {
        for (int i = 0; i < femalesList.Count(); i++)
        {
            for (int j = (i + 1); j < femalesList.Count(); j++)
            {
                if (femalesList[i] == femalesList[j])
                {
                    femalesList.RemoveAt(j);
                }
            }
        }
    }
      private static void sortMales(List<string> malesList)
    {
        for (int i = 0; i < malesList.Count() - 1; i++)
        {
            for (int j = i + 1; j < malesList.Count(); j++)
            {

                int cmpVal = malesList[i].CompareTo(malesList[j]);

                if (cmpVal > 0 && cmpVal != 0)
                {
                    swapString(malesList, i, j);
                }
            }
        }
    }

    private static void sortFemales(List<string> femalesList)
    {
        for (int i = 0; i < femalesList.Count() - 1; i++)
        {
            for (int j = i + 1; j < femalesList.Count(); j++)
            {

                int cmpVal = femalesList[i].CompareTo(femalesList[j]);

                if (cmpVal > 0 && cmpVal != 0)
                {
                    swapString(femalesList, i, j);
                }
            }
        }
    }

    private static void deleteMalesDuplicates(List<string> malesList)
    {
        for (int i = 0; i < malesList.Count(); i++)
        {
            for (int j = (i + 1); j < malesList.Count(); j++)
            {
                if (malesList[i] == malesList[j])
                {
                    malesList.RemoveAt(j);
                }
            }
        }
    }
 private static void writeOutput(List<int> pList, List<string> fList, List<string> mList)
    {
        for (int i = 0; i < pList.Count(); i++)
        {
            if (pList[i] < 80)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("output.txt", true))
                {
                    file.WriteLine(mList[i] + " matches " + fList[i] + " " + pList[i] + "%");
                }
            }
            else
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("output.txt", true))
                {
                    file.WriteLine(mList[i] + " matches " + fList[i] + " " + pList[i] + "%, good match");
                }
            }
        }
    }

      private static bool checkIsAlpha(List<string> malesList, List<string> femalesList)
    {
       bool IsAlpha = true;
        for (int i = 0; i < malesList.Count(); i++)
        {
            if (!IsAlphabets(malesList[i]))
            {
                IsAlpha = false;
            }
        }
        for (int i = 0; i < femalesList.Count(); i++)
        {
            if (!IsAlphabets(femalesList[i]))
            {
                IsAlpha = false;
            }
        }

        return IsAlpha;
    }
      private static void sortingPercentages(List<int> pList, List<string> fList, List<string> mList)
    {
        for (int i = pList.Count() - 1; i >= 1; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                if (pList[j] < pList[j + 1])
                {
                    SwapInts(pList, j + 1, j);
                    swapString(fList, j + 1, j);
                    swapString(mList, j + 1, j);
                }
            }
        }
    }

       private static void doMatches(string match1, List<string> malesList, List<string> femalesList, List<int> pList, List<string> fList, List<string> mList)
    {
        for (int i = 0; i < malesList.Count(); i++)
        {
            for (int j = 0; j < femalesList.Count(); j++)
            {
                char[] nameA = (malesList[i]).ToLower().ToCharArray();
                char[] nameB = (femalesList[j]).ToLower().ToCharArray();
                char[] match = match1.ToCharArray();

                List<int> matchCount = list(nameA, nameB, match);
                List<int> percentage = doReduction(matchCount);
                int p = getPercentage(percentage);

                pList.Add(p);
                fList.Add(femalesList[j]);
                mList.Add(malesList[i]);
            }
        }
    }
  static void Main()
    {
        List<string> malesList = getMales("file.txt");
        List<string> femalesList = getFemales("file.txt");

        deleteFemalesDuplicates(femalesList);
        deleteMalesDuplicates(malesList);

        sortFemales(femalesList);
        sortMales(malesList);

        bool IsAlpha = checkIsAlpha(malesList, femalesList);
        List<int> pList = new List<int>();
        List<string> fList = new List<string>();
        List<string> mList = new List<string>();

        if (IsAlpha)
        {
            doMatches("matches", malesList, femalesList, pList, fList, mList);
            sortingPercentages(pList, fList, mList);
            writeOutput(pList, fList, mList);
        }

        else
        {
            Console.WriteLine("please make sure your file contains alphabetical names only");
        }
    }
}

