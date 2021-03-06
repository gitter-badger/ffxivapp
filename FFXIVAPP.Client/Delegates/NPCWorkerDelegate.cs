﻿// FFXIVAPP.Client
// NPCWorkerDelegate.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

using System;
using System.Collections.Concurrent;
using FFXIVAPP.Common.Core.Memory;

namespace FFXIVAPP.Client.Delegates
{
    public static class NPCWorkerDelegate
    {
        #region Collection Access & Modification

        public static void EnsureNPCEntity(UInt32 key, ActorEntity entity)
        {
            NPCEntities.AddOrUpdate(key, entity, (k, v) => entity);
        }

        public static ActorEntity GetNPCEntity(UInt32 key)
        {
            ActorEntity npc;
            NPCEntities.TryGetValue(key, out npc);
            return npc;
        }

        public static bool RemoveNPCEntity(UInt32 key)
        {
            ActorEntity removed;
            return NPCEntities.TryRemove(key, out removed);
        }

        #endregion

        #region Declarations

        private static ConcurrentDictionary<UInt32, ActorEntity> _npcEntities;

        public static ConcurrentDictionary<UInt32, ActorEntity> NPCEntities
        {
            get { return _npcEntities ?? (_npcEntities = new ConcurrentDictionary<UInt32, ActorEntity>()); }
            private set { _npcEntities = value; }
        }

        #endregion
    }
}
