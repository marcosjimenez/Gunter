using Infrastructure.EvengArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class Delegates
    {
        public delegate void GunterItemAddedDelegate(object sender, GunterSolutionItemEventArgs e);
        public delegate void GunterItemRemovedDelegate(object sender, GunterSolutionItemEventArgs e);
        public delegate void GunterItemShowDelegate(object sender, GunterSolutionItemEventArgs e);
    }
}
