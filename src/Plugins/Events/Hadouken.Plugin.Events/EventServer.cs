﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadouken.Plugins.Events
{
    public class EventServer : IEventServer
    {
        private readonly string _listenUri;

        public EventServer(string listenUri)
        {
            _listenUri = listenUri;
        }

        public void Start()
        {
            //TODO: Implementation
        }

        public void Stop()
        {
            //TODO: Implementation
        }
    }
}
