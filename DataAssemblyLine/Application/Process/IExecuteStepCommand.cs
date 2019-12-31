﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Application.Process
{
    public interface IExecuteStepCommand : IRequest<Unit>
    {
    }
}
