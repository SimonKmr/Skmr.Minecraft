using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using System.Net;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Skmr.Minecraft.Server.Stoper;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<APIGatewayProxyResponse> FunctionHandler(ILambdaContext context)
    {
        try
        {
            string instanceId = Environment.GetEnvironmentVariable("INSTANCE_ID");
            var instances = new List<string>() { instanceId };
            AmazonEC2Client ec2Client = new AmazonEC2Client();

            //Get Status of instance
            DescribeInstanceStatusRequest requestDescribeInstanceStatus = new DescribeInstanceStatusRequest()
            {
                InstanceIds = instances
            };
            DescribeInstanceStatusResponse responseDescribe = await ec2Client.DescribeInstanceStatusAsync(requestDescribeInstanceStatus);

            var InstanceState = responseDescribe.InstanceStatuses.First().InstanceState;

            //if instance is running
            if (InstanceState.Code == 16)
            {
                //Stop instance
                StopInstancesRequest requestStop = new StopInstancesRequest(instances);
                StopInstancesResponse responseStop = await ec2Client.StopInstancesAsync(requestStop);

                //return state of instance
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body = JsonSerializer.Serialize("stopped")
                };
            }

            //else
            //return state of instance
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonSerializer.Serialize(InstanceState)
            };
        }
        catch (Exception e)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonSerializer.Serialize(e)
            };
        }
    }
}
