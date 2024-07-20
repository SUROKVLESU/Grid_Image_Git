using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class ServiceCubic
{
    public static CubicKangeFilled[] CreateArrayCubicV1()
    {
        int minSize = 15;
        int maxSize = 36;
        CubicKangeFilled[] cubicKangeFilleds = new CubicKangeFilled[200];
        int index = 0;
        CubicKangeFilled SelectedCubic =
            new CubicKangeFilled(new Vector2Int(0, Random.Range(15, 36)), new Vector2Int(Random.Range(minSize, maxSize), 0));
        cubicKangeFilleds[index] = SelectedCubic;
        index++;

        Vector2Int upperLeft = new Vector2Int(SelectedCubic.LeftX, SelectedCubic.LeftY);
        Vector2Int upperRight = new Vector2Int(SelectedCubic.RightX, SelectedCubic.LeftY);
        while (true)
        {
            Vector2Int[] vectors1 = NewCubicKangeFilled(upperLeft, upperRight);
            upperLeft = vectors1[0];
            upperRight = vectors1[1];

            if (upperRight.x > 100 && upperRight.y > 100) break;
        }
        CubicKangeFilled[] arr = new CubicKangeFilled[index];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = cubicKangeFilleds[i];
        }

        return arr;


        Vector2Int[] NewCubicKangeFilled(Vector2Int upperLeft, Vector2Int upperRight)
        {
            Vector2Int newLeft =
                new Vector2Int(upperLeft.x, upperLeft.y + Random.Range(minSize, maxSize));
            Vector2Int newRight =
                new Vector2Int(upperLeft.x + Random.Range(minSize, maxSize), upperRight.y);
            if (newRight.x <= upperRight.x)
            {
                if (newLeft.y <= 100)
                {
                    cubicKangeFilleds[index] = new CubicKangeFilled(newLeft, newRight);
                    index++;
                    cubicKangeFilleds[index] =
                    new CubicKangeFilled(new Vector2Int(newRight.x, newLeft.y), upperRight);
                    index++;
                    upperLeft = newLeft;
                    upperRight = new Vector2Int(upperRight.x, cubicKangeFilleds[index - 1].LeftY);
                }
                else
                {
                    cubicKangeFilleds[index] = new CubicKangeFilled(new Vector2Int(newLeft.x, 100), newRight);
                    index++;
                    cubicKangeFilleds[index] =
                    new CubicKangeFilled(new Vector2Int(newRight.x, 100), upperRight);//////
                    index++;
                    upperLeft = new Vector2Int(upperLeft.x, 1000);
                    upperRight = new Vector2Int(upperRight.x, 1000);
                }
            }
            else
            {
                if (newLeft.y <= 100)
                {
                    cubicKangeFilleds[index] = new CubicKangeFilled(newLeft, upperRight);
                    index++;
                    upperLeft = newLeft;
                    upperRight = new Vector2Int(upperRight.x, newLeft.y);
                }
                else
                {
                    cubicKangeFilleds[index] = new CubicKangeFilled(new Vector2Int(newLeft.x, 100), upperRight);
                    index++;
                    upperLeft = new Vector2Int(upperLeft.x, 1000);
                    upperRight = new Vector2Int(upperRight.x, 1000);
                }
            }
            if (upperRight.y >= 100)
            {
                if (upperLeft.x == 100)
                {
                    upperLeft = new Vector2Int(1000, 1000);
                    upperRight = new Vector2Int(1000, 1000);
                    return new Vector2Int[] { upperLeft, upperRight };
                }
                upperLeft = new Vector2Int(upperRight.x, 0);
                upperRight = new Vector2Int(upperRight.x + Random.Range(minSize, maxSize), 0);
                if (upperRight.x > 100)
                {
                    upperRight = new Vector2Int(100, 0);
                }
                return new Vector2Int[] { upperLeft, upperRight };
            }
            return new Vector2Int[] { upperLeft, upperRight };
        }
    }
    public static CubicKangeFilled[] CreateArrayCubicV2()
    {
        int minSize = 15;
        int maxSize = 36;
        CubicKangeFilled[] cubicKangeFilleds = new CubicKangeFilled[300];
        int index = 0;
        CubicKangeFilled SelectedCubic =
            new CubicKangeFilled(new Vector2Int(0, Random.Range(minSize, maxSize)), new Vector2Int(Random.Range(minSize, maxSize), 0));
        cubicKangeFilleds[index] = SelectedCubic;
        index++;
        Vector2Int T1 = new Vector2Int(SelectedCubic.LeftX,SelectedCubic.LeftY);
        Vector2Int T2 = new Vector2Int(SelectedCubic.RightX, SelectedCubic.LeftY);
        Vector2Int T3= new Vector2Int(SelectedCubic.RightX, SelectedCubic.RightY);
        Vector2Int[] result;
        while (T3.x!=100&&T3.y!=100)
        {
            result = NewCubicKangeFilled(T1, T2, T3);
            T1=result[0];
            T2=result[1];
            T3=result[2];
        }

        CubicKangeFilled[] arr = new CubicKangeFilled[index];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = cubicKangeFilleds[i];
        }

        return arr;

        Vector2Int[] NewCubicKangeFilled(Vector2Int T1, Vector2Int T2,Vector2Int T3)
        {
            Vector2Int NT1;
            Vector2Int NT2;
            Vector2Int NT3;

            if(T1.y == 100)
            {
                T1 = new Vector2Int(T3.x,T3.y+ Random.Range(minSize, maxSize));
                if(T1.y > 100)
                {
                    T1 = new Vector2Int(T1.x, 100);
                }
                T2 = new Vector2Int(T1.x+Random.Range(minSize, maxSize),T1.y);
                if(T2.x > 100)
                {
                    T2 = new Vector2Int(100, T2.y);
                }
                T3 = new Vector2Int(T2.x,T3.y);
            }
            if(T3.x == 100)
            {
                T3 = new Vector2Int(T1.x + Random.Range(minSize, maxSize),T1.y);
                if(T3.x > 100)
                {
                    T3 = new Vector2Int(100, T3.y);
                }
                T1 = new Vector2Int(T1.x,T1.y+ Random.Range(minSize, maxSize));
                if(T1.y > 100)
                {
                    T1 = new Vector2Int(T1.x, 100);
                }
                T2 = new Vector2Int(T3.x, T1.y);

            }

            NT1 = new Vector2Int(T1.x, T1.y + Random.Range(minSize, maxSize));
            Vector2Int PT2 = NT1;
            Vector2Int PT1 = NT1;
            if (NT1.y < 100)
            {
                if (100 - NT1.y > minSize)
                {
                    do
                    {
                        PT2 = new Vector2Int(PT2.x + Random.Range(minSize, maxSize), NT1.y);
                        if (PT2.x - T2.x < minSize)
                        {
                            PT2 = new Vector2Int(PT2.x + minSize, PT2.y);
                        }
                        if (100 - PT2.x < minSize)
                        {
                            PT2 = new Vector2Int(T2.x + (100 - T2.x) / 2, PT2.y);
                        }
                        if (PT2.x <= 100)
                        {
                            cubicKangeFilleds[index] = new CubicKangeFilled
                                (PT1, new Vector2Int(PT2.x, PT1.y));
                            PT1 = new Vector2Int(cubicKangeFilleds[index].LeftX, cubicKangeFilleds[index].LeftY);
                            PT2 = new Vector2Int(cubicKangeFilleds[index].RightX, cubicKangeFilleds[index].LeftY);
                            index++;
                        }
                        else
                        {
                            PT2 = new Vector2Int(100, PT2.y);
                            cubicKangeFilleds[index] = new CubicKangeFilled
                                (PT1, new Vector2Int(PT2.x, PT1.y));
                            PT1 = new Vector2Int(cubicKangeFilleds[index].LeftX, cubicKangeFilleds[index].LeftY);
                            PT2 = new Vector2Int(cubicKangeFilleds[index].RightX, cubicKangeFilleds[index].LeftY);
                            index++;
                        }
                    }
                    while (PT2.x < T2.x);
                }
                else
                {
                    NT1 = new Vector2Int(NT1.x, T1.y + (100 - T1.y) / 2);
                    do
                    {
                        PT2 = new Vector2Int(PT2.x + Random.Range(minSize, maxSize), NT1.y);
                        if (PT2.x - T2.x < minSize)
                        {
                            PT2 = new Vector2Int(PT2.x + minSize, PT2.y);
                        }
                        if (100 - PT2.x < minSize)
                        {
                            PT2 = new Vector2Int(T2.x + (100 - T2.x) / 2, PT2.y);
                        }
                        if (PT2.x <= 100)
                        {
                            cubicKangeFilleds[index] = new CubicKangeFilled
                                (PT1, new Vector2Int(PT2.x, PT1.y));
                            PT1 = new Vector2Int(cubicKangeFilleds[index].LeftX, cubicKangeFilleds[index].LeftY);
                            PT2 = new Vector2Int(cubicKangeFilleds[index].RightX, cubicKangeFilleds[index].LeftY);
                            index++;
                        }
                        else
                        {
                            PT2 = new Vector2Int(100, PT2.y);
                            cubicKangeFilleds[index] = new CubicKangeFilled
                                (PT1, new Vector2Int(PT2.x, PT1.y));
                            PT1 = new Vector2Int(cubicKangeFilleds[index].LeftX, cubicKangeFilleds[index].LeftY);
                            PT2 = new Vector2Int(cubicKangeFilleds[index].RightX, cubicKangeFilleds[index].LeftY);
                            index++;
                        }
                    }
                    while (PT2.x < T2.x);
                }
            }
            else
            {
                NT1 = new Vector2Int(NT1.x, 100);
                do
                {
                    PT2 = new Vector2Int(PT2.x + Random.Range(minSize, maxSize), NT1.y);
                    if (PT2.x - T2.x < minSize)
                    {
                        PT2 = new Vector2Int(PT2.x + minSize, PT2.y);
                    }
                    if (100 - PT2.x < minSize)
                    {
                        PT2 = new Vector2Int(T2.x + (100 - T2.x) / 2, PT2.y);
                    }
                    if (PT2.x <= 100)
                    {
                        cubicKangeFilleds[index] = new CubicKangeFilled
                            (PT1, new Vector2Int(PT2.x, PT1.y));
                        PT1 = new Vector2Int(cubicKangeFilleds[index].LeftX, cubicKangeFilleds[index].LeftY);
                        PT2 = new Vector2Int(cubicKangeFilleds[index].RightX, cubicKangeFilleds[index].LeftY);
                        index++;
                    }
                    else
                    {
                        PT2 = new Vector2Int(100, PT2.y);
                        cubicKangeFilleds[index] = new CubicKangeFilled
                            (PT1, new Vector2Int(PT2.x, PT1.y));
                        PT1 = new Vector2Int(cubicKangeFilleds[index].LeftX, cubicKangeFilleds[index].LeftY);
                        PT2 = new Vector2Int(cubicKangeFilleds[index].RightX, cubicKangeFilleds[index].LeftY);
                        index++;
                    }
                }
                while (PT2.x < T2.x);
            }
            NT2 = PT2;
            Vector2Int PT3 = new Vector2Int(PT2.x, T1.y - Random.Range(minSize, maxSize));
            if (PT3.y < 0)
            {
                PT3 = new Vector2Int(PT3.x, 0);
            }
            Vector2Int PT4 = T2;
            Vector2Int PT5 = new Vector2Int(NT2.x, T2.y);
            do
            {
                PT5 = new Vector2Int(PT5.x, PT5.y - Random.Range(minSize, maxSize));
                if (PT5.y < 0)
                {
                    PT5 = new Vector2Int(PT5.x, 0);
                }
                cubicKangeFilleds[index] = new CubicKangeFilled(PT4, PT5);
                index++;
                PT4 = new Vector2Int(PT4.x, PT5.y);
            }
            while (PT5.y != 0);
            NT3 = PT5;
            Debug.Log(index);
            return new Vector2Int[] {NT1,NT2,NT3 };
        }
    }
}

