using PV178.Homeworks.HW02.Machine.States;
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
        private IDictionary<Coordinates, Stock> _coordinatesAndGoods = new Dictionary<Coordinates, Stock>();

        public IState State => throw new NotImplementedException();

        public Stock GetStockFromCoordinates(Coordinates coordinates)
        {
            var stockDict = GetStocksDictionary();

            return stockDict[coordinates];
        }

        public IDictionary<Coordinates, Stock> GetStocksDictionary()
        {
            return _coordinatesAndGoods;
        }

        public void SetStockOnCoordinates(Coordinates coordinates, Stock stock)
        {
            GetStocksDictionary().Add(coordinates, stock);
        }

        public void SwitchToState(IState state)
        {
            throw new NotImplementedException();
        }

        public ControlUnit(int[] rowIdentifiers, char[] columnIdentifiers)
        {
            

        }
    }
}
