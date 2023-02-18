using PV178.Homeworks.HW02.Machine.States;
using PV178.Homeworks.HW02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Machine.ControlUnit
{
    internal class ControlUnit : IControlUnit
    {
        public IState State => throw new NotImplementedException();

        public Stock GetStockFromCoordinates(Coordinates coordinates)
        {
            throw new NotImplementedException();
        }

        public IDictionary<Coordinates, Stock> GetStocksDictionary()
        {
            throw new NotImplementedException();
        }

        public void SetStockOnCoordinates(Coordinates coordinates, Stock stock)
        {
            throw new NotImplementedException();
        }

        public void SwitchToState(IState state)
        {
            throw new NotImplementedException();
        }
    }
}
