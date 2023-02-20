﻿using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Machine.States
{
    public class SelectCoordinatesState : State
    {
        public SelectCoordinatesState(IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;
        }

        public SelectCoordinatesState(IState state, IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;

            Credit = state.Credit;

            SelectedCoordinates = state.SelectedCoordinates;
        }

        public override void RaiseCredit(decimal value)
        {
            throw new NotImplementedException();
        }

        public override void SelectProduct(Coordinates coordinates)
        {
            CheckCredit();

            if (Credit > 0)
            {
                if (AreCoordinatesValid(coordinates) && ControlUnit.GetStocksDictionary()[coordinates] != null)
                {
                    Console.WriteLine($"Row: {coordinates.RowIndex} and column: {coordinates.ColumnIndex} are now selected.");

                    SelectedCoordinates = coordinates;
                }
                else if (AreCoordinatesValid(coordinates) && ControlUnit.GetStocksDictionary()[coordinates] == null)
                {
                    Console.WriteLine($"There is no stock available at {coordinates}");
                }
                else
                {
                    throw new ArgumentException(String.Format($"{coordinates} are not valid coordinates."));
                }
            }
        }

        public override void TryDeliverProduct()
        {
            throw new NotImplementedException();
        }
    }
}
