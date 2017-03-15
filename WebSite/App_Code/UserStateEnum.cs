using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserStateEnum 的摘要说明
/// </summary>
public enum UserStateEnum
{
	/// <summary>
	/// 用户已锁定
	/// </summary>
    LockState=0,
    /// <summary>
    /// 用户正常状态
    /// </summary>
    NormalState=1,
    /// <summary>
    /// 用户审核尚未通过
    /// </summary>
    CheckState=2
}