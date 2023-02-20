﻿using PV178.Homeworks.HW02.Machine.States;
using PV178.Homeworks.HW02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Machine.ControlUnit
{
    public class ControlUnit : IControlUnit
    {
        private readonly IDictionary<Coordinates, Stock> _coordinatesAndGoods = new Dictionary<Coordinates, Stock>();

        private int[] RowIdentifiers { get; set; }

        private char[] ColumnIdentifiers { get; set; }

        public IState State { get; private set; }

        public Stock GetStockFromCoordinates(Coordinates coordinates)
        {
            try
            {
                var stockDict = GetStocksDictionary();

                if (stockDict.ContainsKey(coordinates))
                {
                    return stockDict[coordinates];
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Inserted coordinates are invalid. ");
            }

            return null;
        }

        public IDictionary<Coordinates, Stock> GetStocksDictionary()
        {
            return _coordinatesAndGoods;
        }

        public void SetStockOnCoordinates(Coordinates coordinates, Stock stock)
        {
            try
            {
                if (RowIdentifiers.Contains(coordinates.RowIndex) && ColumnIdentifiers.Contains(coordinates.ColumnIndex))
                {
                    GetStocksDictionary().Add(coordinates, stock);
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Inserted coordinates does not exist. ");
            }
        }

        public void SwitchToState(IState state)
        {
            State = state;
        }

        public ControlUnit(int[] rowIdentifiers, char[] columnIdentifiers)
        {
            RowIdentifiers = rowIdentifiers;

            ColumnIdentifiers = columnIdentifiers;
        }
    }
}
