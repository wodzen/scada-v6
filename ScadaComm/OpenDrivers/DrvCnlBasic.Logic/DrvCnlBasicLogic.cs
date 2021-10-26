﻿// Copyright (c) Rapid Software LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Scada.Comm.Channels;
using Scada.Comm.Config;

namespace Scada.Comm.Drivers.DrvCnlBasic.Logic
{
    /// <summary>
    /// Implements the driver logic.
    /// <para>Реализует логику драйвера.</para>
    /// </summary>
    public class DrvCnlBasicLogic : DriverLogic
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DrvCnlBasicLogic(ICommContext commContext)
            : base(commContext)
        {
        }

        /// <summary>
        /// Gets the driver code.
        /// </summary>
        public override string Code
        {
            get
            {
                return DriverUtils.DriverCode;
            }
        }

        /// <summary>
        /// Creates a new communication channel.
        /// </summary>
        public override ChannelLogic CreateChannel(ILineContext lineContext, ChannelConfig channelConfig)
        {
            switch (channelConfig.TypeCode)
            {
                case ChannelTypeCode.SerialPort:
                    return new SerialPortChannelLogic(lineContext, channelConfig);

                case ChannelTypeCode.TcpClient:
                    return new TcpClientChannelLogic(lineContext, channelConfig);

                case ChannelTypeCode.TcpServer:
                    return new TcpServerChannelLogic(lineContext, channelConfig);

                case ChannelTypeCode.Udp:
                    return new UdpChannelLogic(lineContext, channelConfig);

                default:
                    return null;
            }
        }
    }
}
