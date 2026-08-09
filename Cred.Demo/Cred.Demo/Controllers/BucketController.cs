using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cred.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IAmazonS3 _amazonS3;
        public BucketController(IAmazonS3 amazonS3)
        {
            // The default location of the .aws folder differs between platforms; by default it's in %UserProfile%\.aws.
            // Do NOT hard-code credentials in source. Use dependency injection, environment variables, or the shared credentials file.
            _amazonS3 = amazonS3;
        }
        [HttpGet("lists")]
        public async Task<IActionResult> GetBuckets()
        {
            // If you need a client with explicit credentials for local testing, load them from a secure location (not source).
            // Example (DO NOT store keys in code):
            // var creds = new Amazon.Runtime.BasicAWSCredentials("<ACCESS_KEY>", "<SECRET_KEY>");
            // using var client = new AmazonS3Client(creds, Amazon.RegionEndpoint.APSoutheast2);

            var data = await _amazonS3.ListBucketsAsync();
            var bucketNames = data.Buckets.Select(b => b.BucketName).ToList();
            return Ok(bucketNames);
        }
    }
}
