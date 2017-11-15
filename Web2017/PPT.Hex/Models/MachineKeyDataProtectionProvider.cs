using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT.Hex.Models
{
    using DataProtectionProviderDelegate = Func<string[], Tuple<Func<byte[], byte[]>, Func<byte[], byte[]>>>;
    using DataProtectionTuple = Tuple<Func<byte[], byte[]>, Func<byte[], byte[]>>;
    public class MachineKeyDataProtectionProvider
    {
        public virtual MachineKeyDataProtector Create(params string[] purposes)
        {
            return new MachineKeyDataProtector(purposes);
        }

        public virtual DataProtectionProviderDelegate ToOwinFunction()
        {
            return purposes =>
            {
                MachineKeyDataProtector dataProtecter = Create(purposes);
                return new DataProtectionTuple(dataProtecter.Protect, dataProtecter.Unprotect);
            };
        }
    }
    public class MachineKeyDataProtector
    {
        private readonly string[] _purposes;

        public MachineKeyDataProtector(params string[] purposes)
        {
            _purposes = purposes;
        }
        public virtual byte[] Protect(byte[] userData)
        {
            return new byte[] { };//MachineKey.Protect(userData, _purposes);
        }

        public virtual byte[] Unprotect(byte[] protectedData)
        {
            return new byte[] { };// MachineKey.Unprotect(protectedData, _purposes);
        }
    }

    public class AppBuilder
    {
        public AppBuilder()
        {
            _properties = new Dictionary<string, object>();
        }

        private readonly IDictionary<string, object> _properties;
        public IDictionary<string, object> Properties
        {
            get { return _properties; }
        }

    }

    public class Test
    {
        public void Run()
        {
            var builder = new AppBuilder();

            builder.Properties["security.DataProtectionProvider"] = new MachineKeyDataProtectionProvider().ToOwinFunction();
        }
    }
}
