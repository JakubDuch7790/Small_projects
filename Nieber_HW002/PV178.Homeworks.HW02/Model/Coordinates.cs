﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Model
{
    internal class Coordinates
    {
        public int RowIndex { get; private set; }

        public char ColumnIndex { get; private set; }

        //nechapem
        public static Coordinates Empty { get;  }
           

        public struct Coordinatess
        {
            public static int RowIndex
            {
                get
                {
                    return 0;
                }
            }
            public static char ColumnIndex
            {
                get
                {
                    return '0';
                }
            }
        }

        public Coordinates(int rowIndex, char columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public override string ToString()
        {
            return $"{RowIndex};{ColumnIndex}";
        }
    }
}
