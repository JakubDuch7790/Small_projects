using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Model
{
    public struct Coordinates
    {
        public int RowIndex { get; private set; }

        public char ColumnIndex { get; private set; }

        public static readonly Coordinates Empty = new Coordinates(0, '\0');
           
        public Coordinates(int rowIndex, char columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public override string ToString()
        {
            return $"[{RowIndex};{ColumnIndex}]";
        }
    }
}
