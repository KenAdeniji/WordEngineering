using System;
using NBitcoin;

/*
	2021-06-28T18:19:00 https://programmingblockchain.gitbook.io/programmingblockchain/introduction/project_setup
*/
namespace InformationInTransit.BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! " + new Key().GetWif(Network.Main));
        }
    }
}
