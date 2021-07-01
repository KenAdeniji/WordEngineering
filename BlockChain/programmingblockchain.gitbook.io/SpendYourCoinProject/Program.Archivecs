using System;

using NBitcoin;

/*
	2021-06-28T19:29:00 https://programmingblockchain.gitbook.io/programmingblockchain/bitcoin_transfer/spend_your_coin
*/
namespace SpendYourCoinProject
{
    class Program
    {
        static void Main(string[] args)
        {
// Replace this with Network.Main to do this on Bitcoin MainNet
/*
var network = Network.TestNet;

var privateKey = new Key();
var bitcoinPrivateKey = privateKey.GetWif(network);
var address = bitcoinPrivateKey.GetAddress();

Console.WriteLine(bitcoinPrivateKey); //cQs5w8p4bFdJdtoSM6g6pTwkhFiLn6tXKRm4DS3Gn6F5PhgRRQ1D
Console.WriteLine(address);	//msJ3w1hT8VJ5jXfm99KFGezrvHM3cYrBYE
*/
var bitcoinPrivateKey = new BitcoinSecret("cQs5w8p4bFdJdtoSM6g6pTwkhFiLn6tXKRm4DS3Gn6F5PhgRRQ1D", Network.TestNet);
var network = bitcoinPrivateKey.Network;
var address = bitcoinPrivateKey.GetAddress();

Console.WriteLine(bitcoinPrivateKey); // cN5YQMWV8y19ntovbsZSaeBxXaVPaK4n7vapp4V56CKx5LhrK2RS
Console.WriteLine(address); // mkZzCmjAarnB31n5Ke6EZPbH64Cxexp3Jp		
        }
    }
}
