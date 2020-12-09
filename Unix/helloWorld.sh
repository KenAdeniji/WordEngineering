function getCurrentUser()
{
    username=$USER

    echo $username    

}

function getHostname()
{

   computername=$HOSTNAME

   echo $computername
}

function getTSFormatted(){

    #get current timestamp
    tsFormatted="$(date +'%a %Y-%m-%d %I:%M %p')"

    echo $tsFormatted


}

username=$(getCurrentUser)

computerName=$(getHostname)

tsFormatted=$(getTSFormatted)

log="Hello $username. You are using host $computerName.  Your Current time is $tsFormatted"

echo "$log"


