using Supermortal.Common.PCL.Abstract;
using Supermortal.Common.PCL.Helpers;
using Supermortal.Common.Web.Helpers.Log;

namespace Supermortal.Common.Web
{
  public static class Bootstraper
  {

    public static void Start(IIoCHelper iocHelper, string log4NetConfigFilePath, bool useEncryption = false)
    {
      if (iocHelper != null)
      {
        IoCHelper.Instance = iocHelper;
        AddBindings();
      }

      if (!string.IsNullOrEmpty(log4NetConfigFilePath))
        LogHelper.Configure(log4NetConfigFilePath, useEncryption);
    }

    private static void AddBindings()
    {
      //IoCHelper.Instance.BindService<IGeocoderService, GoogleGeocoderService>();
    }

  }
}
