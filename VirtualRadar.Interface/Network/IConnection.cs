﻿// Copyright © 2014 onwards, Andrew Whewell
// All rights reserved.
//
// Redistribution and use of this software in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//    * Neither the name of the author nor the names of the program's contributors may be used to endorse or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHORS OF THE SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VirtualRadar.Interface.Network
{
    /// <summary>
    /// Describes a single connection exposed by an <see cref="IConnector"/>.
    /// </summary>
    /// <remarks>
    /// Exceptions caught by the connection are channeled through the owning <see cref="IConnector"/>
    /// with the sender set to the <see cref="IConnection"/> object.
    /// </remarks>
    public interface IConnection : IDisposable
    {
        /// <summary>
        /// Gets the current state of the connection.
        /// </summary>
        ConnectionStatus ConnectionStatus { get; }

        /// <summary>
        /// Gets the connector that owns this connection.
        /// </summary>
        IConnector Connector { get; }

        /// <summary>
        /// Raised when <see cref="ConnectionStatus"/> changes.
        /// </summary>
        event EventHandler ConnectionStateChanged;

        /// <summary>
        /// Abandons the connection, closing and destroying it.
        /// </summary>
        /// <remarks>
        /// Abandoning a connection is irreversible, you cannot make
        /// any further calls on it.
        /// </remarks>
        void Abandon();

        /// <summary>
        /// Reads the next chunk from the connection.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="readDelegate"></param>
        /// <remarks>
        /// The call is non-blocking.
        /// </remarks>
        void Read(byte[] buffer, ConnectionReadDelegate readDelegate);

        /// <summary>
        /// Reads the next chunk from the connection.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="readDelegate"></param>
        void Read(byte[] buffer, int offset, int length, ConnectionReadDelegate readDelegate);
    }
}