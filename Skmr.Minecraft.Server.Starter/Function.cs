using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Skmr.Minecraft.Server.Starter;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<List<string>> FunctionHandler(ILambdaContext context)
    {

        AmazonEC2Client ec2Client = new AmazonEC2Client();
        RunInstancesRequest requestLaunch = new RunInstancesRequest();

        var instanceIds = new List<string>();

        RunInstancesResponse responseLaunch = await ec2Client.RunInstancesAsync(requestLaunch);

        foreach( Instance item in responseLaunch.Reservation.Instances)
        {
            instanceIds.Add(item.InstanceId);
        }

        return instanceIds;
    }
}
