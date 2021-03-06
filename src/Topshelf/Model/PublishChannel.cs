﻿// Copyright 2007-2010 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Topshelf.Model
{
	using Stact;


	public class PublishChannel :
		UntypedChannel,
		IServiceChannel
	{
		readonly IServiceChannel _channel;
		readonly UntypedChannel _inbox;

		public PublishChannel(IServiceChannel channel, UntypedChannel inbox)
		{
			_channel = channel;
			_inbox = inbox;
		}

		public void Send<T>(T message)
		{
			_channel.Send(message);
			_inbox.Send(message);
		}
	}
}