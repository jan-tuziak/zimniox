using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimnioX.Models
{
    public record AllData
    (
        string DateTime,
        string Institute,
        string JobId,
        string Owner,
        List<CryptoAssetModel> CryptoAssets
    );
}
