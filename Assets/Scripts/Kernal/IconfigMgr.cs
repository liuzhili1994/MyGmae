using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kernel
{
    public interface IconfigMgr
    {
        //接口里只能定义属性 和方法 方法不能有实体    不能定义字段

            //默认的属性和方法都为public

        Dictionary<string, string> GetAppSetting { get;  }
        
        int GetAppSettingMaxNum() ;

    }
}

