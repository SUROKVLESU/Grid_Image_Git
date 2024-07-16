using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class ServiceCubic
{
    public static CubicKangeFilled[] CreateArrayCubic()
    {
        CubicKangeFilled[] cubicKangeFilleds = new CubicKangeFilled[200];
        int index = 0;
        CubicKangeFilled SelectedCubic = 
            new CubicKangeFilled(new Vector2Int(0,Random.Range(15,36)),new Vector2Int(Random.Range(15, 36),0));

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
        for (int i = 0;i<arr.Length;i++)
        {
            arr[i]= cubicKangeFilleds[i];
        }

        return arr;


        Vector2Int[] NewCubicKangeFilled(Vector2Int upperLeft, Vector2Int upperRight)
        {
            Vector2Int newLeft =
                new Vector2Int(upperLeft.x, upperLeft.y + Random.Range(15, 36));
            Vector2Int newRight =
                new Vector2Int(upperLeft.x + Random.Range(15, 36), upperRight.y);
            if (newRight.x <= upperRight.x) 
            {
                if (newLeft.y <= 100) 
                {
                    cubicKangeFilleds[index] = new CubicKangeFilled(newLeft,newRight);
                    index++;
                    cubicKangeFilleds[index] =
                    new CubicKangeFilled(new Vector2Int(newRight.x, newLeft.y), upperRight);
                    index++;
                    upperLeft = newLeft;
                    upperRight = new Vector2Int(upperRight.x, cubicKangeFilleds[index-1].LeftY);
                }
                else
                {
                    cubicKangeFilleds[index] = new CubicKangeFilled(new Vector2Int(newLeft.x,100), newRight);
                    index++;
                    cubicKangeFilleds[index] =
                    new CubicKangeFilled(new Vector2Int(newRight.x, newLeft.y), upperRight);
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
            if (upperRight.y>=100)
            {
                if (upperLeft.x == 100)
                {
                    upperLeft = new Vector2Int(1000, 1000);
                    upperRight = new Vector2Int(1000, 1000);
                    return new Vector2Int[] { upperLeft, upperRight };
                }
                upperLeft = new Vector2Int(upperRight.x, 0);
                upperRight = new Vector2Int(upperRight.x+ Random.Range(15, 36), 0);
                if(upperRight.x>100)
                {
                    upperRight = new Vector2Int(100, 0);
                }
                return new Vector2Int[] { upperLeft, upperRight };
            }
            return new Vector2Int[] {upperLeft, upperRight};
        }
    }
}

