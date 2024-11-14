using System;
using System.Net;
using System.Runtime.InteropServices;

namespace WordEngineering
{
 /// <summary>UtilityDynamicHostConfigurationProtocolDHCPArgument</summary>
 public class UtilityDynamicHostConfigurationProtocolDHCPArgument
 {
  /// <summary>server</summary>
  public string server;

  /// <summary>Constructor</summary>
  public UtilityDynamicHostConfigurationProtocolDHCPArgument():this
  (
   null //server
  )
  {
  }
  
  /// <summary>Constructor</summary>
  public UtilityDynamicHostConfigurationProtocolDHCPArgument
  (
   string server
  )
  {
   this.server = server;  	
  }
 }
 
 /// <summary>UtilityDynamicHostConfigurationProtocolDHCP</summary>
 /// <remarks>
 ///  GotDotNet.com/Community/UserSamples/Details.aspx?SampleGuid=3407CA64-7CC2-49B6-8047-C053526E33E5
 ///  %SystemRoot%\system32\dhcpmgmt.msc /s
 ///  Scope
 ///   Start IP address 10.0.1.0   | 10.0.1.1         | 10.0.1.1            10.0.1.65
 ///   End IP address 10.0.254.254 | 10.0.1.126       | 10.0.1.62           10.0.1.126
 ///   Length 16                   |                  |
 ///   Subnet mask 255.255.0.0     | 255.255.255.128  | 255.255.255.192     255.255.255.192
 ///   Activate
 ///  Authorize
 /// </remarks>
 public class UtilityDynamicHostConfigurationProtocolDHCP
 {
  ///<summary>PreferredMaximum</summary> 	
  public const int PreferredMaximum = 2048;

  /// <summary>DHCP_BINARY_DATA</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DHCP_BINARY_DATA
  {
   /// <summary>DataLength</summary>
   public int DataLength;

   /// <summary>Data</summary>
   public IntPtr Data; //byte array
   
  }
        
  /// <summary>DHCP_CLIENT_INFO</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DHCP_CLIENT_INFO
  {
   /// <summary>ClientIpAddress</summary>
   public int ClientIpAddress;
   
   /// <summary>SubnetMask</summary>
   public int SubnetMask;

   /// <summary>ClientHardwareAddress</summary>
   public DHCP_BINARY_DATA ClientHardwareAddress;

   /// <summary>ClientName</summary>
   public String ClientName;

   /// <summary>ClientComment</summary>
   public String ClientComment;

   /// <summary>ClientLeaseExpires</summary>
   public DHCP_DATE_TIME ClientLeaseExpires;

   /// <summary>OwnerHost</summary>
   public DHCP_HOST_INFO OwnerHost;
  }
        
  /// <summary>DHCP_CLIENT_INFO_ARRAY</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DHCP_CLIENT_INFO_ARRAY
  {
   /// <summary>NumElements</summary>
   public int NumElements;

   /// <summary>Clients</summary>
   public IntPtr Clients;
  }

  /// <summary>DHCP_DATE_TIME</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DHCP_DATE_TIME
  {
   /// <summary>dwLowDateTime</summary>
   public int dwLowDateTime;

   /// <summary>dwHighDateTime</summary>
   public int dwHighDateTime;
  }

  /// <summary>DHCP_HOST_INFO</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DHCP_HOST_INFO
  {
   /// <summary>IpAddress</summary>
   public int IpAddress;

   /// <summary>NetBiosName</summary>
   public string NetBiosName;

   /// <summary>HostName</summary>
   public string HostName;

  }
  
  /// <summary>DHCP_IP_ARRAY</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DHCP_IP_ARRAY
  {
   /// <summary>NumElements</summary>
   public int NumElements;

   /// <summary>Elements</summary>
   public IntPtr Elements;
  }
  
  /// <summary>DhcpEnumSubnets</summary>
  [DllImport("dhcpsapi.dll", SetLastError=true)]
  public static extern int DhcpEnumSubnets
  (
       string ServerIPAddress,
   ref int    ResumeHandle,
       int    PreferredMaximum,
   ref IntPtr EnumInfo,
   ref int    ElementsRead,
   ref int    ElementsTotal
  );

  /// <summary>DhcpEnumSubnetClients</summary>
  [DllImport("dhcpsapi.dll", SetLastError=true)]
  public static extern int DhcpEnumSubnetClients
  (
       string ServerIPAddress,
       int    SubnetAddress,       
   ref int    ResumeHandle,
       int    PreferredMaximum,
   ref IntPtr ClientInfo,
   ref int    ClientsRead,
   ref int    ClientsTotal
  );
  
  /// <summary>DhcpGetVersion</summary>
  [DllImport("dhcpsapi.dll", SetLastError=true)]
  public static extern int DhcpGetVersion
  (
       string ServerIPAddress,
   ref int    MajorVersion,
   ref int    MinorVersion
  );

  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of command line arguments</param>
  public static void Main(String[] argv)
  {
   Boolean               booleanParseCommandLineArguments      =  false;
   string                exceptionMessage                      =  null;     
   UtilityDynamicHostConfigurationProtocolDHCPArgument  utilityDynamicHostConfigurationProtocolDHCPArgument =  null;
   
   utilityDynamicHostConfigurationProtocolDHCPArgument = new UtilityDynamicHostConfigurationProtocolDHCPArgument();
   
   booleanParseCommandLineArguments =  UtilityParseCommandLineArgument.ParseCommandLineArguments
   ( 
    argv, 
    utilityDynamicHostConfigurationProtocolDHCPArgument
   );

   if ( booleanParseCommandLineArguments == false )
   {
    // error encountered in arguments. Display usage message
    System.Console.Write
    (
     UtilityParseCommandLineArgument.CommandLineArgumentsUsage( typeof ( UtilityDynamicHostConfigurationProtocolDHCPArgument ) )
    );
    return;
   }//if ( booleanParseCommandLineArguments  == false )
   Stub
   (
    ref utilityDynamicHostConfigurationProtocolDHCPArgument,
    ref exceptionMessage
   );
  }
  
  /// <summary>Stub</summary>
  public static void Stub
  (
   ref UtilityDynamicHostConfigurationProtocolDHCPArgument utilityDynamicHostConfigurationProtocolDHCPArgument,
   ref string                                              exceptionMessage
  )
  {
   IntPtr[]              enumInfoElements                =  null;
   IPAddress[]           ipAddressDhcpEnumSubnets        =  null;
   DHCP_CLIENT_INFO[][]  dhcpClientInfoEnumSubnetClient  =  null;
   DhcpGetVersionStub
   (
   	ref utilityDynamicHostConfigurationProtocolDHCPArgument,
   	ref exceptionMessage
   );
   DhcpEnumSubnetsStub
   (
   	ref utilityDynamicHostConfigurationProtocolDHCPArgument,
   	ref exceptionMessage,
   	ref ipAddressDhcpEnumSubnets,
   	ref enumInfoElements
   );
   DhcpEnumSubnetClientstub
   (
   	ref utilityDynamicHostConfigurationProtocolDHCPArgument,
   	ref exceptionMessage,
   	ref ipAddressDhcpEnumSubnets,
   	ref enumInfoElements,
   	ref dhcpClientInfoEnumSubnetClient
   );
  }

  /// <summary>DhcpEnumSubnetClientstub</summary>
  public static void DhcpEnumSubnetClientstub
  (
   ref UtilityDynamicHostConfigurationProtocolDHCPArgument utilityDynamicHostConfigurationProtocolDHCPArgument,
   ref string                                              exceptionMessage,
   ref IPAddress[]                                         ipAddress,
   ref IntPtr[]                                            enumInfoElements,
   ref DHCP_CLIENT_INFO[][]                                dhcpClientInfo
  )
  {
   int dhcpEnumSubnetClients;
   int clientsRead = -1;
   int clientsTotal = -1;   
   int resumeHandle = 0;
   IntPtr clientInfo = IntPtr.Zero;
   IntPtr clientInfoClient = IntPtr.Zero;
   IntPtr clientInfoClients = IntPtr.Zero;
   DHCP_CLIENT_INFO_ARRAY dhcpClientInfoArray;
   dhcpClientInfo = null;
   if ( ipAddress == null ) return;
   dhcpClientInfo = new DHCP_CLIENT_INFO[ ipAddress.Length ][];
   for ( int ipAddressIndex = 0; ipAddressIndex < ipAddress.Length; ++ipAddressIndex )
   {
    dhcpEnumSubnetClients = DhcpEnumSubnetClients
    (
    	 ipAddress[ipAddressIndex].ToString(),
         Marshal.ReadInt32( enumInfoElements[ipAddressIndex] ),
     ref resumeHandle,
         PreferredMaximum,
     ref clientInfo,
     ref clientsRead,
     ref clientsTotal
    );
    System.Console.WriteLine
    (
     "dhcpEnumSubnetClients: {0}",
     dhcpEnumSubnetClients     
    );
    if ( dhcpEnumSubnetClients == 0 && clientInfo != IntPtr.Zero )
    {
   	 dhcpClientInfoArray = ( DHCP_CLIENT_INFO_ARRAY ) Marshal.PtrToStructure
     (
      clientInfo,
      typeof( DHCP_CLIENT_INFO_ARRAY )
   	 );
   	 dhcpClientInfo[ipAddressIndex] = new DHCP_CLIENT_INFO[dhcpClientInfoArray.NumElements];
   	 clientInfoClients = dhcpClientInfoArray.Clients;
     for ( int clientIndex = 0; clientIndex < clientsTotal; ++clientIndex )
     {
      clientInfoClient = Marshal.ReadIntPtr( clientInfoClients );
      dhcpClientInfo[ipAddressIndex][clientIndex] = ( DHCP_CLIENT_INFO ) Marshal.PtrToStructure
      (
       clientInfoClient,
       typeof( DHCP_CLIENT_INFO )
      );
      #if ( DEBUG )
       System.Console.WriteLine
       (
        "IPAddress[{0}][{1}]: {2}",
        ipAddressIndex,        
        clientIndex,
        dhcpClientInfo[ipAddressIndex][clientIndex]
       );
      #endif 
      clientInfoClient = new IntPtr
      ( 
       clientInfoClients.ToInt32() + IntPtr.Size
      );
     }
    }
   }
  }
  
  /// <summary>DhcpEnumSubnetsStub</summary>
  public static void DhcpEnumSubnetsStub
  (
   ref UtilityDynamicHostConfigurationProtocolDHCPArgument utilityDynamicHostConfigurationProtocolDHCPArgument,
   ref string                                              exceptionMessage,
   ref IPAddress[]                                         ipAddress,
   ref IntPtr[]                                            enumInfoElements
  )
  {
   int dhcpEnumSubnets = -1;
   int elementsRead = -1;
   int elementsTotal = -1;
   int resumeHandle = 0;
   IntPtr enumInfo = IntPtr.Zero;
   DHCP_IP_ARRAY dhcpIPArray;
   ipAddress = null;
   dhcpEnumSubnets = DhcpEnumSubnets
   (
        utilityDynamicHostConfigurationProtocolDHCPArgument.server,
    ref resumeHandle,
        PreferredMaximum,
    ref enumInfo,
    ref elementsRead,
    ref elementsTotal
   );
   if ( elementsTotal < 1 ) { return; }
   if ( dhcpEnumSubnets == 0 && enumInfo != IntPtr.Zero )
   {
    dhcpIPArray = (DHCP_IP_ARRAY)Marshal.PtrToStructure
    (
     enumInfo,
     typeof(DHCP_IP_ARRAY)
    );
    ipAddress = new IPAddress[ elementsTotal ];
    enumInfoElements = new IntPtr[ elementsTotal ];
    enumInfoElements[0] = dhcpIPArray.Elements;
    for ( int elementIndex = 0; elementIndex < elementsTotal; ++elementIndex )
    {
     ipAddress[elementIndex] = new IPAddress
     (
      IPAddress.NetworkToHostOrder
      (
       Marshal.ReadInt32( enumInfoElements[elementIndex] )
      )
     );
     #if ( DEBUG )
      System.Console.WriteLine
      (
       "[{0}]: IPAddress: {1} | Subnet Mask: {2}",
       elementIndex,
       ipAddress[elementIndex],
       Marshal.ReadInt32( enumInfoElements[elementIndex] )
      );
     #endif
     if ( elementIndex < elementsTotal - 1 )
     {
      enumInfoElements[elementIndex + 1] = new IntPtr
      ( 
       enumInfoElements[elementIndex].ToInt32() + IntPtr.Size
      );
     }
    }
   }
  }

  /// <summary>DhcpGetVersionStub</summary>
  public static void DhcpGetVersionStub
  (
   ref UtilityDynamicHostConfigurationProtocolDHCPArgument utilityDynamicHostConfigurationProtocolDHCPArgument,
   ref string                                              exceptionMessage
  )
  {
   int dhcpGetVersion = -1;
   int majorVersion = -1;
   int minorVersion = -1;   
   dhcpGetVersion = DhcpGetVersion
   (
        utilityDynamicHostConfigurationProtocolDHCPArgument.server,
    ref majorVersion,
    ref minorVersion
   );
   #if ( DEBUG )
    System.Console.WriteLine
    (
     "Dhcp Major Version: {0} | Minor Version: {1}",
   	 majorVersion,
   	 minorVersion
    );
   #endif 
  }
  
  static UtilityDynamicHostConfigurationProtocolDHCP()
  {
  } 
 }
}
