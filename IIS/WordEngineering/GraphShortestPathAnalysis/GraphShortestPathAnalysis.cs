using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

using System.Collections.Generic;

// this project creates and deploys a CLR stored procedeure that does 
// graph shortest path analysis


public partial class GraphShortestPathAnalysis
{
  [Microsoft.SqlServer.Server.SqlProcedure]
  public static void csp_ShortestPath(System.Data.SqlTypes.SqlInt64 startNode, SqlInt64 endNode, SqlInt32 maxNodesToCheck, out SqlString pathResult, out SqlDouble distResult)
  {
    // Put your code here. OK, I will!
    Dictionary<long, double> distance = new Dictionary<long, double>(); // curr shortest distance (double) from startNode to (key) node
    Dictionary<long, long> previous = new Dictionary<long, long>(); // predecessor values to construct the actual path when done
    Dictionary<long, bool> beenAdded = new Dictionary<long, bool>();  // has node been added to the queue yet? Once added, we don't want to add again
    MyPriorityQueue PQ = new MyPriorityQueue();

    SqlConnection conn = null;

    long startNodeAsLong = (long)startNode;
    long endNodeAsLong = (long)endNode;
    int maxNodesToCheckAsInt = (int)maxNodesToCheck;

    // initialize start node
    distance[startNodeAsLong] = 0.0;    // distance from start node to itself is 0
    previous[startNodeAsLong] = -1;     // -1 is the code for undefined.
    PQ.Enqueue(new NodeDistance(startNodeAsLong, 0.0));  // the queue holds distance information because Enqueue and Dequeue need it to keep queue ordered by priority. alt approach would be to store only node IDs and then do a distance lookup
    beenAdded[startNodeAsLong] = true;

    try
    {
      //string connString = "context connection=true";  // the sp is running on the db server so we use a local connection but MultipleActiveResultSets=True not allowed
      string connString = "Server=(local);Database=GraphShortestPathAnalysis;Trusted_Connection=True;MultipleActiveResultSets=True";  // to allow two datareaders

      conn = new SqlConnection(connString);  // Note: the 'using()' construction seems to have a bad perf impact so we explicitly open and close
      conn.Open();

      double alt = 0.0;  // 'test distance'

      while (PQ.Count() > 0 && beenAdded.Count < maxNodesToCheckAsInt)
      {
        NodeDistance u = PQ.Dequeue();  // node with shortest distance from start
        if (u.nodeID == endNode) break;  // found the target end node

        // fetch all neighbors (v) of u
        SqlCommand cmd = new SqlCommand("select toNode from tblGraph where fromNode=" + u.nodeID);
        cmd.Connection = conn;  // cmd.CommandTimeout can be set here

        long v;  // ID of a neighbor to u
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read() == true)                   // if there are no neighbors, this loop will exit immediately
        {
          v = long.Parse(sdr[0].ToString());

          if (beenAdded.ContainsKey(v) == false) // first appearance of node v
          {
            distance[v] = double.MaxValue;        // stand-in for infinity
            previous[v] = -1;                 // undefined
            PQ.Enqueue(new NodeDistance(v, double.MaxValue));  // maxValue is a dummy value
            beenAdded[v] = true;
          }

          SqlCommand distCmd = new SqlCommand("select edgeWeight from tblGraph where fromNode=" + u.nodeID + " and toNode=" + v);
          distCmd.Connection = conn;
          double d = Convert.ToDouble( distCmd.ExecuteScalar());
 
          //alt = distance[u.nodeID] + 1.0;  // if all edge weights are just hops can simplify to this
          alt = distance[u.nodeID] + d;  // alt = dist(start-to-u) + dist(u-to-v), so alt is total distance from start to v

          if (alt < distance[v])  // is alt a new, shorter distance from start to v?
          {
            distance[v] = alt;
            previous[v] = u.nodeID;
            PQ.ChangePriority(v, alt);  // this will change the distance/priority 
          }

        }  // sdr Read loop
        sdr.Close();

      } // main while loop on PQ.Count > 0

      conn.Close();  // no more selects needed

      // extract the shortest path as a string from the previous[] array
      pathResult = "NOTREACHABLE";   // default result string
      distResult = -1.0;      // distance result defaults to -1 == unreachable

      if (distance.ContainsKey(endNodeAsLong) == true)  // endNode was encountered at some point in the algorithm
      {
        double sp = distance[endNodeAsLong];  // shortest path distance
        if (sp != double.MaxValue)       // we have a reachable path
        {
          pathResult = "";
          long currNode = endNodeAsLong;
          while (currNode != startNodeAsLong)  // construct the path as  semicolon delimited string
          {
            pathResult += currNode.ToString() + ";";
            currNode = previous[currNode];
          }
          pathResult += startNode.ToString();   // tack on the start node
          distResult = sp;                      // the distance result
        }
      }

    } // try

    catch(Exception ex) // typically Out Of Memory or a Command TimeOut
    {
      pathResult = ex.Message;
      distResult = -1.0;
    }

    finally
    {
      if (conn != null && conn.State == ConnectionState.Open)
        conn.Close();
    }


  }  // csp_ShortestPath()
};  // class StoredProcedures

// =================================

public class NodeDistance
{
  public long nodeID;
  public double distance;

  public NodeDistance(long nodeID, double distance)
  {
    this.nodeID = nodeID;
    this.distance = distance;
  }

  public override string ToString()
  {
    return "[ " + nodeID + " " + distance.ToString("F1") + " ]";
  }
}

public class MyPriorityQueue
{
  public List<NodeDistance> list;

  public MyPriorityQueue()
  {
    this.list = new List<NodeDistance>();
  }

  private int IndexOf(long nodeID)
  {
    for (int i = 0; i < list.Count; ++i)
      if (list[i].nodeID == nodeID)
        return i;
    return -1;
  }

  private int IndexOfSmallestDist()
  {
    double smallDist = this.list[0].distance;
    int smallIndex = 0;
    for (int i = 0; i < list.Count; ++i)
    {
      if (list[i].distance < smallDist)
      {
        smallDist = list[i].distance;
        smallIndex = i;
      }
    }
    return smallIndex;
  }

  public NodeDistance Dequeue()
  {
    int i = IndexOfSmallestDist();
    NodeDistance result = list[i];
    list.RemoveAt(i);
    return result;
  }

  public void Enqueue(NodeDistance nd)
  {
    list.Add(nd);
  }

  public void ChangePriority(long nodeID, double newDist)
  {
    int i = IndexOf(nodeID);
    list[i].distance = newDist;
  }

  public int Count()
  {
    return this.list.Count;
  }

  public override string ToString()
  {
    string s = "";
    for (int i = 0; i < list.Count; ++i)
      s += list[i] + " ";
    return s;
  }

} // MyPriorityQueue
