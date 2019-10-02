using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands
{
    public class CreateJobCommand: IRequest
    {
        public string JobName { get; set; }
    }
}
