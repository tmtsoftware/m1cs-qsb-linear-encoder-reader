using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    internal interface IConnectionStatusListener
    {
        void ConnectionStatusChanged(ConnectionStatus newStatus);
    }

    internal interface IStatisticsStateListener
    {
        void StatisticsStateChanged(StatisticsState newState);
    }
}
