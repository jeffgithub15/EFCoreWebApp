using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IDemo
    {
        void Execute();
    }

    public class Demo : IDemo
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }


}

                                                                                                     
