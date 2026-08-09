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
            //The default location of the .aws folder differs between platforms, by default the folder is located in %UserProfile%\.aws.
            _amazonS3 = amazonS3;
        }
        [HttpGet("lists")]
        public async Task<IActionResult> GetBuckets()
        {
            //var s3clients=new AmazonS3Client("AKIAWULE447AQOPU24OC", "ziy3z7O9M0HwYvfh01da6G2IZYnymZeM5qFx7FvA", Amazon.RegionEndpoint.APSoutheast2);
            var data = await _amazonS3.ListBucketsAsync();
            var bucketNames = data.Buckets.Select(b => b.BucketName).ToList();
            return Ok(bucketNames);
        }
    }
}
