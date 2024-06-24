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
        void InvalidMessageReceived(string message);
    }

    internal interface IEncoderCountListener
    {
        void EncoderCountChanged(EncoderCount newCount);
    }

    internal interface IRecorderStatusListener
    {
        void RecorderStatusChanged(RecorderStatus newStatus);
    }
}
