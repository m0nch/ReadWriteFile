using System.Collections.Generic;

namespace ReadWriteFile
{
    public class _AppCache : _IAppCache
    {
        public Dictionary<string, object> _ViewBag { get; set; }

        public _AppCache()
        {
            _ViewBag = new Dictionary<string, object>();    
        }
    }    
    public interface _IAppCache
    {
        Dictionary<string, object> _ViewBag { get; set; }
    }
}
