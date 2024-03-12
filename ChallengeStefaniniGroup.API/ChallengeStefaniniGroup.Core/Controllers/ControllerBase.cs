using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Core.Controllers
{
    public class ControllerBase : Controller
    {
        public static (ObjectId, string) ConvertStringToObjectId(string id)
        {
            try
            {
                return (ObjectId.Parse(id), string.Empty);
            }
            catch (Exception ex)
            {
                return (new(), ex.Message);
            }
        }
    }
}
