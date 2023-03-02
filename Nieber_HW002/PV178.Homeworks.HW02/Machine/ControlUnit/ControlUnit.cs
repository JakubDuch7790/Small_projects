using PV178.Homeworks.HW02.Machine.States;
using PV178.Homeworks.HW02.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PV178.Homeworks.HW02.Machine.ControlUnit
{
    public class ControlUnit : IControlUnit
    {
        private readonly IDictionary<Coordinates, Stock> _coordinatesAndGoods = new Dictionary<Coordinates, Stock>();

        private int[] RowIdentifiers { get; set; }

        private char[] ColumnIdentifiers { get; set; }

        public IState State { get; private set; }

        public ControlUnit(int[] rowIdentifiers, char[] columnIdentifiers)
        {
            RowIdentifiers = rowIdentifiers;

            ColumnIdentifiers = columnIdentifiers;

            SwitchToState(new InsertCoinState(this));
        }

        public Stock GetStockFromCoordinates(Coordinates coordinates)
        {
            var stockDict = GetStocksDictionary();

            if (stockDict.ContainsKey(coordinates) && stockDict[coordinates].Quantity > 0)
            {
                return stockDict[coordinates];
            }
            else if (stockDict.ContainsKey(coordinates) && stockDict[coordinates].Quantity <= 0)
            {
                return null;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IDictionary<Coordinates, Stock> GetStocksDictionary()
        {
            return _coordinatesAndGoods;
        }

        public void SetStockOnCoordinates(Coordinates coordinates, Stock stock)
        {
            if (RowIdentifiers.Contains(coordinates.RowIndex) && ColumnIdentifiers.Contains(coordinates.ColumnIndex))
            { 
                GetStocksDictionary().Add(coordinates, stock);
            }
            else
            {
                throw new ArgumentException("Invalid coordinates.");
            }
        }

        public void SwitchToState(IState state)
        {
            State = state;
        }
    }
}
