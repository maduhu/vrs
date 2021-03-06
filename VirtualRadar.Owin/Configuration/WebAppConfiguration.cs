﻿// Copyright © 2017 onwards, Andrew Whewell
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using InterfaceFactory;
using Owin;
using VirtualRadar.Interface.Owin;

namespace VirtualRadar.Owin.Configuration
{
    /// <summary>
    /// Default implementation of <see cref="IWebAppConfiguration"/>.
    /// </summary>
    class WebAppConfiguration : IWebAppConfiguration
    {
        /// <summary>
        /// The list of callbacks that will register middleware for us.
        /// </summary>
        private List<RegisterMiddlewareCallback> _Callbacks = new List<RegisterMiddlewareCallback>();

        /// <summary>
        /// The list of stream manipulators that should be used by the <see cref="IResponseStreamWrapper"/> (if present).
        /// </summary>
        private List<RegisterStreamManipulator> _StreamManipulators = new List<RegisterStreamManipulator>();

        /// <summary>
        /// The configuration object that is exposed by <see cref="GetHttpConfiguration"/>.
        /// </summary>
        private HttpConfiguration _HttpConfiguration;

        /// <summary>
        /// See interface docs.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public IWebAppConfigurationCallbackHandle AddCallback(Action<IAppBuilder> callback, int priority)
        {
            if(callback == null) {
                throw new ArgumentNullException(nameof(callback));
            }

            var result = new RegisterMiddlewareCallback(callback, priority);
            _Callbacks.Add(result);

            return result;
        }

        /// <summary>
        /// See interface docs.
        /// </summary>
        /// <param name="configureCallbackHandle"></param>
        public void RemoveCallback(IWebAppConfigurationCallbackHandle configureCallbackHandle)
        {
            if(configureCallbackHandle == null) {
                throw new ArgumentNullException(nameof(configureCallbackHandle));
            }

            _Callbacks.Remove((RegisterMiddlewareCallback)configureCallbackHandle);
        }

        /// <summary>
        /// See interface docs.
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configure(IAppBuilder appBuilder)
        {
            if(appBuilder == null) {
                throw new ArgumentNullException(nameof(appBuilder));
            }

            _HttpConfiguration = new HttpConfiguration();

            foreach(var callback in _Callbacks.OrderBy(r => r.Priority)) {
                callback.Callback(appBuilder);
            }
        }

        /// <summary>
        /// See interface docs.
        /// </summary>
        /// <returns></returns>
        public HttpConfiguration GetHttpConfiguration()
        {
            return _HttpConfiguration;
        }

        /// <summary>
        /// See interface docs.
        /// </summary>
        /// <param name="streamManipulator"></param>
        /// <param name="priority"></param>
        public void AddStreamManipulator(IStreamManipulator streamManipulator, int priority)
        {
            if(streamManipulator == null) {
                throw new ArgumentNullException(nameof(streamManipulator));
            }

            if(!_StreamManipulators.Any(r => Object.ReferenceEquals(r.StreamManipulator, streamManipulator))) {
                _StreamManipulators.Add(new RegisterStreamManipulator(streamManipulator, priority));
            }
        }

        /// <summary>
        /// See interface docs.
        /// </summary>
        /// <param name="streamManipulator"></param>
        public void RemoveStreamManipulator(IStreamManipulator streamManipulator)
        {
            _StreamManipulators.Remove(_StreamManipulators.FirstOrDefault(r => Object.Equals(r.StreamManipulator, streamManipulator)));
        }

        /// <summary>
        /// See interface docs.
        /// </summary>
        /// <returns></returns>
        public IStreamManipulator[] GetStreamManipulators()
        {
            return _StreamManipulators.OrderBy(r => r.Priority).Select(r => r.StreamManipulator).ToArray();
        }
    }
}
